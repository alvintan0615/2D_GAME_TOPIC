using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public PhysicsMaterial2D Friction1;
    public PhysicsMaterial2D Friction2;
    public static NewPlayerController instance;
    public Animator anim;
    public Animator[] animator = { null, null };
    public string currentHumanState;
    private string currentDemonState;
    public static bool isTimeLineChangeAnim = false;
    [SerializeField]private Demon_Skill demonSkill;

    public static CharacterStats characterStats;
    public SceneFader sceneFaderPrefab;
    [Header("移動設定")]
    private float xInput;
    public float moveSpeed = 8f;
    public float demonMoveSpeed;
    private float finalMoveSpeed;
    public bool facingRight = true;
    [SerializeField] float groundCheckRadius;
    [SerializeField] float frontCheckRadius;
    public GameObject deadPos;
    public GameObject trapPos;

    [Header("跳躍設定")]
    public float jumpForce = 6f;
    public float doubleJumpForce;
    [SerializeField] private int jumpCount = 2;
    public Transform footPoint;
    public Vector2 footBoxSize;
    public bool touchGround = false;
    public bool touchPlatform = false;
    private Coroutine cor_canJump_dead;
    public bool cantJumpMove = false;

    [Header("蹬牆設定")]
    [SerializeField]private bool frontTouchWall = false;
    public Transform frontPoint;
    public bool wallSliding;
    public float wallSidingSpeed;
    bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;
    public Vector2 boxSize;

    [Header("衝刺參數")]
    public float dashTime;
    [SerializeField]private float dashTimeLeft;
    [SerializeField] private float lastDash = -10f;
    public float dashCoolDown;
    public float dashSpeed;

    [Header("攀爬相關")]
    [SerializeField] float climbSpeed = 3f;
    public float naturalGravity;

    [Header("特效相關")]
    [SerializeField] GameObject jumpEffect;
    [SerializeField] GameObject fireSkillEffect;
    [SerializeField] Transform skillEffectPoint;

    [Header("自動回血、扣血相關")]
    public float humanNormalHealTime;
    float humanTimer;
    public float demonNormalInjuryTime;
    float demonTimer;

    [Header("精靈回血")]
    public bool hasFairy;
    public GameObject healingEffect;
    public float healingTime;

    [Header("死亡相關")]
    public bool isDead = false;
    private bool isdeaded = false;

    #region HUMAN_Animation State
    const string HUMAN_IDLERUN = "Human_IdleRun";
    const string HUMAN_JUMPON = "Human_JumpOn";
    const string HUMAN_JUMPDOWN = "Human_JumpDown";
    const string HUMAN_DASH = "Human_Dash";
    const string HUMAN_STICKWALL = "Human_StickWall";
    const string HUMAN_CLIMB = "Human_Climb";
    const string HUMAN_STOPCLIMB = "Human_StopClimb";
    const string HUMAN_DEAD = "Human_Dead";
    #endregion

    #region Demon_Animation State
    const string DEMON_IDLERUN = "Demon_IdleRun"; 
    const string DEMON_JUMP = "Demon_Jump";
    const string DEMON_DOUBLEJUMP = "Demon_DoubleJump";
    const string DEMON_DESH = "Demon_Dash";
    const string DEMON_DEAD = "Demon_Dead";
    #endregion

    public AudioSetting audioSetting;
    void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        rb.sharedMaterial = Friction1;
        characterStats = GetComponent<CharacterStats>();
        skillEffectPoint = transform.GetChild(4).transform;
        naturalGravity = rb.gravityScale;
        anim = GetComponent<Animator>();
        demonSkill = transform.GetChild(1).GetComponent<Demon_Skill>();
        for (int x = 0; x < 2; x++)
        {
            animator[x] = this.transform.GetChild(x).GetComponent<Animator>();
        }


        
    }

    private void OnEnable()
    {
        GameManager.Instance.RigisterPlayer(characterStats);
    }

    private void Start()
    {
        audioSetting = GameObject.Find("SFX").GetComponent<AudioSetting>();
    }
    void Update()
    {
        if(GameManager.Instance.notDead == true && characterStats.CurrentHealth <= 0)
            characterStats.CurrentHealth = 1;


        if (characterStats.CurrentHealth <= 0)// && EventManager.Instance.fireVillege_BossStoryLine == false
            isDead = true;


        if (characterStats.CurrentHealth > 0)
            isDead = false;
           
        if(isDead == true)
        {
            EventManager.Instance.isPlayerPosOK = false;
            PlayerStatus.isDead = true;
            GameManager.Instance.NotifyObservers();
            rb.velocity = new Vector2(0,rb.velocity.y);
            if (GameManager.Instance.Ken_Human == true)
            //TODO Dead
                HumanState(HUMAN_DEAD);
            else
                DemonState(DEMON_DEAD);

            if (deadPos != null)
                StartCoroutine(PlayAgain());
            //SceneController.Instance.DeadScene("UITestScene");
        }
        else
        {
            PlayerStatus.isDead = false;
            GameManager.Instance.AgainNotifyObservers();
        }

        if (!isDead)
        {
            Animation();
            xInput = Input.GetAxis("Horizontal");
            GroundCheck();
            Jump();
            StickWall();
            Changing();
            NormalHealInjury();
            FairyHealing();
            ReturnTrapPos();
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (Time.time >= lastDash + dashCoolDown)
                {
                    ReadyToDash();
                }
            }
            anim.SetBool("Change", PlayerStatus.isChanging);
            if (PlayerStatus.isClimbing == true && GameManager.Instance.Ken_Human == true)
            {
                rb.gravityScale = 0f;
                Climb();
            }
            else
                rb.gravityScale = naturalGravity;

            if (Human_Skill.isCirleSkill == true || Human_Skill.isGroundSkill == true || demonSkill.isBeamSkill == true || demonSkill.isAllScreenSkill == true)
            {
                rb.gravityScale = 0f;
                rb.velocity = Vector2.zero;
                //Instantiate(fireSkillEffect, skillEffectPoint.position, Quaternion.identity);
            }

            Changing();

            if (characterStats.CurrentHealth >= characterStats.MaxHealth)
                characterStats.CurrentHealth = characterStats.MaxHealth;

            if (characterStats.CurrentHealingTime >= characterStats.MaxHealingTime)
                characterStats.CurrentHealingTime = characterStats.MaxHealingTime;

            if(isTimeLineChangeAnim == true)
            {
                PlayerState("Change_Human");
            }
        
        }
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            Dash();
            Move();
        }
        
        Friction();

    }

    void Move()
    {
        if (PlayerStatus.canMove)
        {
            if (GameManager.Instance.Ken_Human == true)
            {
                finalMoveSpeed = moveSpeed * 1;
                animator[0].SetFloat("Run", Mathf.Abs(finalMoveSpeed * xInput));
            }
            else
            {
                finalMoveSpeed = moveSpeed * demonMoveSpeed;
                animator[1].SetFloat("Run", Mathf.Abs(finalMoveSpeed * xInput));
            }
                

            if (touchGround)
                cantJumpMove = false;
            
            if (touchGround && cantJumpMove == false && PlayerStatus.isDashing == false)
            {
                rb.velocity = new Vector2(finalMoveSpeed * xInput, rb.velocity.y);
            }
            else if (!touchGround && !wallSliding && xInput != 0 && cantJumpMove == false && PlayerStatus.isDashing == false)
            {
                rb.velocity = new Vector2(finalMoveSpeed * xInput, rb.velocity.y);
                
            }

            if (xInput != 0f)
            {
                if ((facingRight && xInput < 0f) ||
                    (!facingRight && xInput > 0f)) Flip();
            }
            

            if (touchGround && PlayerStatus.canRunAnimation == true && !PlayerStatus.isSkilling && !isDead && PlayerStatus.isDragging == false)
            {
                HumanState(HUMAN_IDLERUN);
                DemonState(DEMON_IDLERUN);
                    /*if (xInput >= 0.5f || xInput <= -0.5f)
                        HumanState(HUMAN_RUN);
                    else
                        HumanState(HUMAN_IDLE);*/
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator[0].SetFloat("Run", 0);
            animator[1].SetFloat("Run", 0);
            return;
        }
    }

    void Jump()
    {
        if (PlayerStatus.canJump == false) return;
        if(PlayerStatus.isJumping == true && Human_Skill.isAttack == true)
        {
            HumanState(HUMAN_JUMPON);
            Human_Skill.isAttack = false;
        }
            

        if (touchGround)
        {
            jumpCount = 2;
            PlayerStatus.isJumping = false;
        }
        if(rb.velocity.y >= 1f && touchGround == false && wallSliding == false && PlayerStatus.isClimbing ==false && !PlayerStatus.isSkilling)
        {
            HumanState(HUMAN_JUMPON);
            DemonState(DEMON_JUMP);
        } 
        else if(rb.velocity.y <= -1f && touchGround == false && wallSliding == false && PlayerStatus.isClimbing == false && !PlayerStatus.isSkilling && !isDead)
            HumanState(HUMAN_JUMPDOWN);
        #region 蹬牆設定
        if (Input.GetButtonDown("Jump") && wallSliding == true && GameManager.Instance.Ken_Human == true)
        {
            wallJumping = true;
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }
        if (wallJumping == true)
        {
            rb.velocity = new Vector2(xWallForce * -xInput, yWallForce);
        }

        #endregion
        if (Input.GetButtonDown("Jump") && touchGround && !Input.GetKey(KeyCode.DownArrow))
        {
            PlayerStatus.isJumping = true;
            if(PlayerStatus.isJumping == true)
            {
                jumpCount--;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                Instantiate(jumpEffect, footPoint.position, Quaternion.identity);
            }
        }
        else if (Input.GetButtonDown("Jump") && !touchGround && GameManager.Instance.Ken_Human == false)
        {
            if (jumpCount > 0)
            {
                jumpCount--;
                rb.velocity = new Vector2(jumpForce * xInput, doubleJumpForce);
                DemonState(DEMON_DOUBLEJUMP);
                PlayerStatus.isJumping = true;
            }
            else
                return;
        }else if(Input.GetButtonDown("Jump") && touchPlatform )
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }
    }


    void Flip()
    {
        if (PlayerStatus.canFlip)
        {
            facingRight = !facingRight;
            Vector3 Scale = transform.localScale;
            Scale.x *= -1;
            transform.localScale = Scale;
        }
        else
            return;
    }

    void Climb()
    {
        float YInput = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump") && YInput == 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            PlayerStatus.isClimbing = false;
            rb.gravityScale = naturalGravity;
            return;
        }
        if (YInput >= 0.1f )
        {
            rb.velocity = new Vector2(0f, YInput * climbSpeed);
            HumanState(HUMAN_CLIMB);
        }
        else if (YInput <= -0.1f)
        {
            rb.velocity = new Vector2(0f, YInput * climbSpeed);
            HumanState(HUMAN_CLIMB);
        }
        else if (YInput == 0f)
        {
            rb.velocity = new Vector2(0f, 0f);
            HumanState(HUMAN_STOPCLIMB);
        }
        
    }

    void StickWall()
    {
        if (frontTouchWall == true && touchGround == false && xInput != 0 && PlayerStatus.canStickWall == true && GameManager.Instance.Ken_Human == true)
            wallSliding = true;
        else
        {
            wallSliding = false;
        }
            

        if (wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSidingSpeed, float.MaxValue));
            HumanState(HUMAN_STICKWALL);
            PlayerStatus.isDashing = false;
        }
    }

    void GroundCheck()
    {
        #region touchGround 0.3 0.8
        touchGround = Physics2D.OverlapBox(footPoint.position, footBoxSize, transform.eulerAngles.z, LayerMask.GetMask("Ground") | LayerMask.GetMask("Platform"));
        if (touchGround == true)
        {
            //PlayerStatus.canJump = true;
            if (cor_canJump_dead != null) StopCoroutine(cor_canJump_dead);
        }
        else
        {
            if (cor_canJump_dead == null)
                cor_canJump_dead = StartCoroutine(canJump_dead());
        }
        #endregion
        frontTouchWall = Physics2D.OverlapBox(frontPoint.position, boxSize, transform.eulerAngles.z, LayerMask.GetMask("Ground"));

        //frontTouchWall = Physics2D.OverlapCircle(frontPoint.position, frontCheckRadius, LayerMask.GetMask("Ground"));
        touchPlatform = Physics2D.OverlapBox(footPoint.position, footBoxSize, transform.eulerAngles.z,LayerMask.GetMask("Platform"));

    }

    IEnumerator canJump_dead()
    {
        yield return new WaitForSeconds(0.2f);
        PlayerStatus.canJump = false;
    }

    void Friction()
    {
        if (touchGround)
        {
            rb.sharedMaterial = Friction1;
        }
        if (!touchGround)
        {
            rb.sharedMaterial = Friction2;
        }
    }



    void SetWallJumpingToFalse()
    {
        wallJumping = false;
    }

    void ReadyToDash()
    {
        if(PlayerStatus.canDash == true)
        {
            PlayerStatus.isDashing = true;

            dashTimeLeft = dashTime;

            lastDash = Time.time;
        }

    }

    void Dash()
    {
        if (PlayerStatus.canDash == false)
            return;
        if (PlayerStatus.isDashing)
        {
            if (GameManager.Instance.Ken_Human == true && dashTimeLeft > 0)
            {
                if(facingRight)
                    StartCoroutine(Dashing(1f,0.8f));
                else
                    StartCoroutine(Dashing(-1f,0.8f));

            }
            else if(GameManager.Instance.Ken_Human == false && dashTimeLeft > 0)
            {
                if (facingRight)
                    StartCoroutine(Dashing(1f, 1.5f));
                else
                    StartCoroutine(Dashing(-1f, 1.5f));
            }


            if (dashTimeLeft <= 0)
            {
                PlayerStatus.isDashing = false;
            }
        }
    }

    void Changing()
    {
        if (PlayerStatus.isChanging == true)
        {
            rb.gravityScale = 0f;
            rb.velocity = Vector2.zero;
        }
        
    }

    void FairyHealing()
    {

        hasFairy = FollowPlayer.isFollowPlayer;
        if(Input.GetKeyDown(KeyCode.D) && PlayerStatus.canHealing == true && FollowPlayer.isFollowPlayer == true 
            && characterStats.CurrentHealingTime > 0 && characterStats.CurrentHealth < characterStats.MaxHealth
            && EventManager.Instance.canUsePotion == true)
        {
            audioSetting.soundEffectAudio[14].Play();
            StartCoroutine(Healing(healingTime));
        }
    }

    void NormalHealInjury()
    {
        if(PlayerStatus.isDialouging == false)
        {
            if (GameManager.Instance.Ken_Human == true)
            {
                humanTimer += Time.deltaTime;
                if (humanTimer >= humanNormalHealTime)
                {
                    GameManager.Instance.playerStats.characterData.currentHealth += 2;
                    humanTimer = 0f;
                }

            }
            else if (GameManager.Instance.Ken_Human == false)
            {
                demonTimer += Time.deltaTime;
                if (demonTimer >= demonNormalInjuryTime)
                {
                    GameManager.Instance.playerStats.characterData.currentHealth -= 4;
                    demonTimer = 0f;
                }

            }
        }
        
    }

    void Animation()
    {
        if(PlayerStatus.isDashing == true && PlayerStatus.canDash == true)
        {
            HumanState(HUMAN_DASH);
            DemonState(DEMON_DESH);
        }
            

    }

    void ReturnTrapPos()
    {
        if (Input.GetKeyDown(KeyCode.PageUp) && trapPos != null)
        {
            this.gameObject.transform.position = trapPos.transform.position;
        }
    }
    public void fireSkillEffectPoint()
    {
        Instantiate(fireSkillEffect, skillEffectPoint.position, Quaternion.identity);
    }

    public void PlayerState(string newState)
    {
        anim.Play(newState);
    }

    public void HumanState(string newState)
    {
        if (currentHumanState == newState || GameManager.Instance.Ken_Human == false) return;

        animator[0].Play(newState);

        currentHumanState = newState;
    }

    public void DemonState(string newState)
    {
        if (currentDemonState == newState || GameManager.Instance.Ken_Human == true) return;

        animator[1].Play(newState);

        currentDemonState = newState;
    }

    IEnumerator Healing(float healingReCover)
    {
        PlayerStatus.isHealing = true;
        characterStats.CurrentHealingTime -= 1;
        characterStats.CurrentHealth += Random.Range(15, 23);
        Instantiate(healingEffect, footPoint.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(healingReCover);
        PlayerStatus.isHealing = false;
    }
    
    public IEnumerator PlayAgain()
    {
        PlayerStatus.isDialouging = true;
        yield return new WaitForSeconds(1f);
        SceneFader fade = Instantiate(sceneFaderPrefab);
        yield return StartCoroutine(fade.FadeOut(1f));
        this.gameObject.transform.position = deadPos.transform.position;
        characterStats.CurrentHealth = characterStats.MaxHealth;
        
        yield return StartCoroutine(fade.FadeIn(1f));
        PlayerStatus.isDialouging = false;
        EventManager.Instance.isPlayerPosOK = true;
    }

    IEnumerator Dashing(float direction,float demonSpeed)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.velocity = new Vector2(dashSpeed * direction * demonSpeed, rb.velocity.y);
        yield return new WaitForSeconds(0.4f);
        rb.velocity = new Vector2(0f, rb.velocity.y);
        PlayerStatus.isDashing = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(footPoint.position, footBoxSize * 2f);
        Gizmos.DrawWireCube(frontPoint.position, boxSize * 2f);
        //Gizmos.DrawWireSphere(frontPoint.position, frontCheckRadius);
    }
}
