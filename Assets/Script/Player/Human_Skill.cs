using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Human_Skill : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public static Human_Skill instance;
    [Header("推拉相關")]
    public float distance = 1f;
    public LayerMask boxMask;
    GameObject box;
    private Transform myTrans;

    [Header("普攻相關")]
    static public Animator animator;
    static public bool isAttack;

    [Header("技能相關")]
    static public bool isCirleSkill;
    static public bool isGroundSkill;
    [SerializeField] private SpriteRenderer effect;

    [Header("技能冷卻")]
    private bool circleSkillIsOn = false;
    private float circleSkillTimer;
    public float circleSkillCD;
    private bool groundSkillIsOn = false;
    private float groundSkillTimer;
    public float groundSkillCD;
    [SerializeField] private Image circleSkillFilledImage;
    [SerializeField] private Image groundSkillFilledImage;

    [Header("受傷")]
    static public bool isHurt;

    [Header("MoveStoneSound")]
    public AudioSetting audioSetting;

    #region Animation State
    private string currentState;
    const string CIRCLESKILL = "Human_CircleSkill";
    const string GROUNDSKILL = "Human_GroundSkill";
    const string HUMAN_HURT = "Human_Hurt";
    #endregion
    void Awake()
    {
        myTrans = transform.parent;
        effect = transform.GetChild(1).GetComponent<SpriteRenderer>();
        rb = GetComponentInParent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        instance = this;
        
    }
    void Start()
    {
        circleSkillFilledImage = GameObject.FindGameObjectWithTag("circleSkillFilledImage").GetComponent<Image>();
        groundSkillFilledImage = GameObject.FindGameObjectWithTag("groundSkillFilledImage").GetComponent<Image>();

        audioSetting = GameObject.Find("SFX").GetComponent<AudioSetting>();
        //audioSetting.soundEffectAudio[18].Play();
        //audioSetting.soundEffectAudio[18].mute = true;
    }

    void Update()
    {
        PullPush();
        NormalAttack();
        CircleSkill();
        GroundSkill();
        HumanSkillIsOn();
        if (PlayerStatus.isChanging == false)
            effect.sprite = null;
        //Debug.Log("isSkilling" + PlayerStatus.isSkilling);
    }

    

    void PullPush()
    {

        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(myTrans.position, Vector2.right * myTrans.localScale.x, distance, boxMask);
        if (hit.collider != null && hit.collider.gameObject.tag == "Pushable" && Input.GetKey(KeyCode.A) && NewPlayerController.instance.touchGround == true)
        {
            PlayerStatus.isDragging = true;
            if(hit.collider.gameObject.transform.position.x < this.GetComponentInParent<Transform>().position.x && Input.GetKey(KeyCode.RightArrow))
            {
                NewPlayerController.instance.HumanState("Human_Pull");
                audioSetting.soundEffectAudio[18].mute = false;
            } 
            else if(hit.collider.gameObject.transform.position.x < this.GetComponentInParent<Transform>().position.x && Input.GetKey(KeyCode.LeftArrow))
            {
                NewPlayerController.instance.HumanState("Human_Push");
                audioSetting.soundEffectAudio[18].mute = false;
            }
                

            if (hit.collider.gameObject.transform.position.x > this.GetComponentInParent<Transform>().position.x && Input.GetKey(KeyCode.RightArrow))
            {
                NewPlayerController.instance.HumanState("Human_Push");
                audioSetting.soundEffectAudio[18].mute = false;
            }
            else if (hit.collider.gameObject.transform.position.x > this.GetComponentInParent<Transform>().position.x && Input.GetKey(KeyCode.LeftArrow))
            {
                NewPlayerController.instance.HumanState("Human_Pull");
                audioSetting.soundEffectAudio[18].mute = false;
            }
                

            box = hit.collider.gameObject;

            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<BoxPull>().beingPushed = true;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponentInParent<Rigidbody2D>();
        }
        else if (hit.collider != null && hit.collider.gameObject.tag == "Pushable" && Input.GetKeyUp(KeyCode.A))
        {
            PlayerStatus.isDragging = false;
            audioSetting.soundEffectAudio[18].mute = true;
            box.GetComponent<FixedJoint2D>().enabled = false;
            box.GetComponent<BoxPull>().beingPushed = false;
        }
    }

    void NormalAttack()
    {
        if (PlayerStatus.canAttack == false) return;
        
        if(NewPlayerController.instance.touchGround == true && PlayerStatus.isJumping == false)
        {
            if (Input.GetButtonDown("Fire1") && PlayerStatus.canAttack == true)
            {
                
                isAttack = true;
                if (isAttack == true && !Input.GetButtonDown("Jump"))
                {
                    //PlayerStatus.canMove = false;
                    //NewPlayerController.instance.HumanState(HUMAN_NORMALATTACK1);
                    //animator.Play("Human_NormalAttack1");
                    PlayerStatus.isAttacking = true;
                    //rb.velocity = new Vector2(0, 0);
                    //PlayerStatus.isAttacking = true;
                }
                else
                {
                    isAttack = false;
                    PlayerStatus.isAttacking = false;
                    return;
                }
            }
        }
    }

    void CircleSkill()
    {
        if (PlayerStatus.canSkill == false) return;

        if (Input.GetButtonDown("Fire2") && PlayerStatus.canSkill == true && isGroundSkill == false && PlayerStatus.isHurting == false && circleSkillIsOn ==false)
        {
            isCirleSkill = true;
            if(isCirleSkill == true)
            {
                PlayerStatus.isSkilling = true;
                NewPlayerController.instance.HumanState(CIRCLESKILL);
                circleSkillIsOn = true;
            }
            else
            {
                isCirleSkill = false;
                PlayerStatus.isSkilling = false;
            }
        }
    }

    void GroundSkill()
    {
        if (PlayerStatus.canSkill == false) return;

        if (Input.GetButtonDown("Fire3") && PlayerStatus.canSkill == true && isCirleSkill == false && PlayerStatus.isHurting == false && groundSkillIsOn == false)
        {
            isGroundSkill = true;
            if (isGroundSkill == true)
            {
                PlayerStatus.isSkilling = true;
                NewPlayerController.instance.HumanState(GROUNDSKILL);
                groundSkillIsOn = true;
            }
            else
            {
                isGroundSkill = false;
                PlayerStatus.isSkilling = false;
            }
        }
    }

    public void Hurt()
    {
        if(PlayerStatus.canBeHurt == true && GameManager.Instance.Ken_Human == true)
        {
            isHurt = true;
            if(isHurt == true)
            {
                PlayerStatus.isHurting = true;
                NewPlayerController.instance.HumanState(HUMAN_HURT);
            }
            else
            {
                isHurt = false;
                PlayerStatus.isHurting = false;
            }
        }
    }

    void HumanSkillIsOn()
    {
        if (circleSkillIsOn == true)
        {
            circleSkillTimer += Time.deltaTime;
            circleSkillFilledImage.fillAmount = (circleSkillCD - circleSkillTimer) / circleSkillCD;
            if (circleSkillTimer >= circleSkillCD)
            {
                circleSkillFilledImage.fillAmount = 0;
                circleSkillIsOn = false;
                circleSkillTimer = 0f;
            }
        }

        if (groundSkillIsOn == true)
        {
            groundSkillTimer += Time.deltaTime;
            groundSkillFilledImage.fillAmount = (groundSkillCD - groundSkillTimer) / groundSkillCD;
            if (groundSkillTimer >= groundSkillCD)
            {
                groundSkillFilledImage.fillAmount = 0;
                groundSkillIsOn = false;
                groundSkillTimer = 0f;
            }
        }
    }

    void HumanState(string newState)
    {
        if (currentState == newState || GameManager.Instance.Ken_Human == false) return;

        animator.Play(newState);

        currentState = newState;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position,(Vector2)transform.position + Vector2.right * transform.localScale.x* distance);
    }
}
