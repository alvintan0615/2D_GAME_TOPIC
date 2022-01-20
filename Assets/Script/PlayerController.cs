using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{

    public Rigidbody2D myRigidbody;

    public BoxCollider2D coll;
    public BoxCollider2D GroundCheck;

    public static PlayerController instance;
    public Animator anim;

    public static CharacterStats characterStats;

    [Header("攻擊判斷")]

    public CircleCollider2D attackTrigger;
    public ContactFilter2D enemyFilter;
    public int enemyCount;
    public Collider2D[] enemyColList;
    [Header ("移動參數")]
    public float runSpeed;
    private float runSpeed2;
    private float moveDir;
    [Header("跳躍參數")]
    public float jumpForce = 6.3f;

    [Header("衝刺參數")]
    public float dashTime;
    private float dashTimeLeft;
    private float lastDash = -10f;
    public float dashCoolDown;
    public float dashSpeed;

    [Header("角色狀態")]
    public bool isOnGround;
    public bool isJump;
    public bool isDoubleJump;
    public bool isAttacking = false;
    public bool isAttack = false;
    public bool isDashing;
    public bool isClimb;
    private bool isDead;
    [Header("環境檢測")]
    public float footOffset = 0.4f;
    public float groundDistance = 0.2f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header("梯子檢測")]
    public bool canClimb = false;
    [HideInInspector] public bool bottomLadder = false;
    [HideInInspector] public bool topLadder = false;
    public Ladder ladder;
    public float naturalGravity;
    [SerializeField] float climbSpeed = 3f;
    [Header("Erosion")]
    public float ErosionTime = 5f;

    //按鍵設置
    public bool jumpPressed;
    public int jumpCount;

    float xVelocity;
    
    void Awake()
    {
        instance = this;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        characterStats = GetComponent<CharacterStats>();
        
        attackTrigger = GameObject.Find("attackTrigger").GetComponent<CircleCollider2D>();
        enemyFilter.SetLayerMask(LayerMask.GetMask("Enemy"));
        
        runSpeed2 = runSpeed;
    }

    void OnEnable()
    {
        GameManager.Instance.RigisterPlayer(characterStats);
    }

    void Start()
    {
        SaveManager.Instance.LoadPlayerData();
        naturalGravity = 3f;
    }

    void Update()
    {

        isDead = characterStats.CurrentHealth == 0;
        if (isDead)
        {
            GameManager.Instance.NotifyObservers();
            return;
        }
        
        if (isClimb == true)
        {
            
            transform.position = new Vector2(ladder.transform.position.x, myRigidbody.position.y);
            myRigidbody.gravityScale = 0f;
            Climb();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(Time.time >= lastDash + dashCoolDown)
            {
                ReadyToDash();
            }
        }
        
        Attack();
        ErosionTime = Mathf.Max(ErosionTime - Time.deltaTime, 0);
        if (ErosionTime == 0)
        {
            characterStats.CurrentErosion = Mathf.Max(characterStats.CurrentErosion - 2, 0);
            ErosionTime = 5f;
        }
            
        playerAnim();
        if (!(Input.GetKey(KeyCode.DownArrow) && Input.GetButtonDown("Jump")))
        {
            if (Input.GetButtonDown("Jump") && jumpCount > 0)
            {
                jumpPressed = true;
                anim.SetBool("isJump", true);
            }
            else if (isAttack == true)
            {
                jumpPressed = false;
                anim.SetBool("isJump", false);
            }
        }

        //jumpPressed = Input.GetButtonDown("Jump");
        enemyColList = new Collider2D[3];
        enemyCount = attackTrigger.OverlapCollider(enemyFilter, enemyColList);
        //Debug.Log(enemyCount);
    }



    private void FixedUpdate()
    {
        PhysicsCheck();
        if(isAttack == true)
        {
            runSpeed = 0f;
        }
        else
        {
            runSpeed = runSpeed2;
            Jump();
        }
        Dash();
        if (isDashing)
            return;
        Run();

    }
    void Run()
    {
        if (isDead) return;
        /*xVelocity = Input.GetAxis("Horizontal");

        myRigidbody.velocity = new Vector2(xVelocity * runSpeed, myRigidbody.velocity.y);*/
        if(PlayerStatus.canMove == true )
        {
            Vector2 playerVel = new Vector2(0, myRigidbody.velocity.y);
            myRigidbody.velocity = playerVel;
        }
        else
        {
            moveDir = Input.GetAxis("Horizontal");
            Vector2 playerVel = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);
            myRigidbody.velocity = playerVel;
            Flip();
        }

        if (canClimb && Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
        {
            isClimb = true;
        }

        //Debug.Log(myRigidbody.velocity);
    }

    void Flip()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasXAxisSpeed)
        {
            if(myRigidbody.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (myRigidbody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    void PhysicsCheck()
    {
        /*RaycastHit2D leftFootCheck = Raycast(new Vector2(-footOffset, -2.65f), Vector2.down, groundDistance, groundLayer);
        RaycastHit2D rightFootCheck = Raycast(new Vector2(footOffset, -2.65f), Vector2.down, groundDistance, groundLayer);*/

        isOnGround = Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
        if(isOnGround == false)
        {
            anim.SetBool("isFall", true);
        }
        /*if (GroundCheck.IsTouchingLayers(groundLayer))
            isOnGround = true;
        else
            isOnGround = false;*/
    }

    void Attack()
    {
        if (isDead) return;
        if (isDashing)
            return;
        if (isOnGround && !isJump)
        {
            if (Input.GetButtonDown("Fire1") && !isAttacking)
            {
                isAttacking = true;
                isAttack = true;
                
                
            }
        }
    }

    void Jump()
    {
        if (isDead) return;


        if (isOnGround)
        {
            jumpCount = 1;
            isJump = false;
            isDoubleJump = false;
        }
        if (jumpCount <= 0)
        {
            jumpCount = 0;
            isDoubleJump = true;
        }
        if (jumpPressed && isOnGround)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            jumpCount--;
            isJump = true;
            
            jumpPressed = false;
        }
        else if(jumpPressed && jumpCount >0 && !isOnGround)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            anim.SetBool("isDoubleJump", true);
            jumpCount--;
            isOnGround = false;
            jumpPressed = false;
        }

        
    }


     void playerAnim()
    {
        anim.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));
        anim.SetBool("isOnGround", isOnGround);
        anim.SetBool("Dead", isDead);
        if (isOnGround)
        {
            anim.SetBool("isFall", false);
        }

        if (anim.GetBool("isJump"))
        {
            if(myRigidbody.velocity.y < 0.0f)
            {
                anim.SetBool("isJump", false);
                anim.SetBool("isFall", true);
            }
        }
        else if (isOnGround)
        {
            anim.SetBool("isFall", false);
            anim.SetBool("isOnGround", isOnGround);
        }

        if (anim.GetBool("isDoubleJump"))
        {
            if (myRigidbody.velocity.y < 0.0f)
            {
                
                anim.SetBool("isDoubleJump", false);
                anim.SetBool("isDoubleFall", true);
            }
        }
        else if (isOnGround)
        {
            anim.SetBool("isDoubleFall", false);
            anim.SetBool("isOnGround", isOnGround);
        }

    }
    #region RaycastHit2D
    /*RaycastHit2D Raycast(Vector2 offset, Vector2 rayDiraction, float length, LayerMask layer)
    {
        Vector2 pos = transform.position + new Vector3(-1,0,0);

        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDiraction, length, layer);

        Debug.DrawRay(pos + offset, rayDiraction * length);
        
        return hit;
    }*/
    #endregion
    #region Animation Event(Damage)
    public void Damage()
    {
        
        useErosion();
        if (enemyCount > 0)
        {
            for(int i = 0; i < enemyCount; i++)
            {
                var enemyStats=enemyColList[i].GetComponent<CharacterStats>();
                enemyStats.TakeDamage(characterStats, enemyStats, 0);
            }
        }
    }
    #endregion

    void useErosion()
    {
        characterStats.CurrentErosion = Mathf.Max(characterStats.CurrentErosion + 3, 0);
        if (characterStats.CurrentErosion >= characterStats.MaxErosion)
            characterStats.CurrentErosion = 100;
        ErosionTime = 5f;
    }

    private void Climb()
    {
        if (Input.GetButtonDown("Jump"))
        {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                isClimb = false;
                myRigidbody.gravityScale = naturalGravity;
                return;
        }
        float vDirection = Input.GetAxis("Vertical");

        if (vDirection > .1f && !topLadder)
        {
            myRigidbody.velocity = new Vector2(0f, vDirection * climbSpeed);
            if (Input.GetButtonDown("Jump"))
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                isClimb = false;
                myRigidbody.gravityScale = naturalGravity;
                return;
            }
        }
        else if (vDirection < -.1f && !bottomLadder)
        {
            myRigidbody.velocity = new Vector2(0f, vDirection * climbSpeed);
            if (Input.GetButtonDown("Jump"))
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                isClimb = false;
                myRigidbody.gravityScale = naturalGravity;
                return;
            }
        }
        else
        {
            myRigidbody.velocity = new Vector2(0f, 0f);
            if (Input.GetButtonDown("Jump"))
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                isClimb = false;
                myRigidbody.gravityScale = naturalGravity;
                return;
            }
        }
    
    }

    void ReadyToDash()
    {
        isDashing = true;

        dashTimeLeft = dashTime;

        lastDash = Time.time;
    }

    void Dash()
    {
        if (isDashing)
        {
            if(dashTimeLeft > 0)
            {
                /*if(myRigidbody.velocity.y >0 && !isOnGround)
                {
                    myRigidbody.velocity = new Vector2(dashSpeed * moveDir, jumpForce);
                }*/
                myRigidbody.velocity = new Vector2(dashSpeed * moveDir, myRigidbody.velocity.y);

                dashTimeLeft -= Time.deltaTime;

                //ShadowPool.Instance.GetFormPool();
            }

            if(dashTimeLeft <= 0)
            {
                isDashing = false;

            }
        }
    }
    
}
