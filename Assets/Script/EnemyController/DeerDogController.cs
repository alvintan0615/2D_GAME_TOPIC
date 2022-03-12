using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum EnemyStates { IDLE, CHASE, PATROL, DEAD }
[RequireComponent(typeof(CharacterStats))]
public class DeerDogController : MonoBehaviour, IEndGameObserver
{
    public Text HP;
    private CharacterStats characterStats;
    public Rigidbody2D rb;
    public EnemyStates enemyStates;
    private SpriteRenderer isFaceLeft;
    private Animator anim;
    bool playerDead;
    public bool isAttack = false;
    [Header("environmental Check")]
    private RaycastHit2D leftFootCheck;
    private RaycastHit2D rightFootCheck;
    public float footOffset = 1.8f;
    public float groundDistance = 1f;
    public float footToGround = 0f;
    public LayerMask groundLayer;
    [Header("Basic Settings")]
    public float speed;
    public float patrolSpeed;
    private Transform myTransform;
    private Transform playerTransform;
    public float sightRadius;
    public bool isIDLE;
    public GameObject attackTarget;
    public float lookAtTime;
    private float remainLookAtTime;
    private float lastAttackTime;
    public bool FoundPlayer = false;
    public float knockbackForce;
    public bool isHurt;
    [Header("Animation Settings")]
    private bool isIdle;
    private bool isChasing;
    
    private bool isDead;
    [Header("PATROL States")]
    public float stoppingDistance;
    public float patrolRange;
    private Vector3 wayPoint;
    private Vector3 idlePos;

    void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
        isFaceLeft = this.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        idlePos = transform.position;
        remainLookAtTime = lookAtTime;
        
    }
    void Start()
    {
        if (isIDLE)
        {
            enemyStates = EnemyStates.IDLE;
        }
        else
        {
            enemyStates = EnemyStates.PATROL;
            GetNewWayPoint();
        }

        myTransform = this.transform;
        if (GameObject.FindWithTag("Player") != null)
        {
            playerTransform = GameObject.FindWithTag("Player").transform;
        }
        GameManager.Instance.AddObserver(this);

    }
    //切換場景時啟用
    /*void OnEnable()
    {
        GameManager.Instance.AddObserver(this);
    }*/

    void OnDisable()
    {
        if (!GameManager.IsInitialized) return;
        GameManager.Instance.RemoveObserver(this);    
    }

    void Update()
    {
        if (characterStats.CurrentHealth == 0)
            isDead = true;
        if (!playerDead)
        {
            SwitchStates();
            SwitchAnimation();
            lastAttackTime -= Time.deltaTime;
        }
        //HP.text = characterStats.CurrentHealth + "/" + characterStats.MaxHealth;

    }

    private void FixedUpdate()
    {
        PhysicsCheck();
    }

    void SwitchAnimation()
    {
        anim.SetBool("Idle", isIdle);
        anim.SetBool("Chasing", isChasing);
        anim.SetBool("Critical", characterStats.isCritical);
        anim.SetBool("Dead", isDead);
    }


    void SwitchStates()
    {
        /* FoundPlayer = Physics2D.OverlapCircle(transform.position, sightRadius, LayerMask.GetMask("Player"));*/
        #region 發現玩家，如果自己沒死，切換到CHASE
        if (isDead)
        {
            enemyStates = EnemyStates.DEAD;
        }
        else if (FoundaPlayer())
        {
            enemyStates = EnemyStates.CHASE;
        }
        
        #endregion
        switch (enemyStates)
        {
            case EnemyStates.IDLE:
                isIdle = true;
                break;
            case EnemyStates.PATROL:

                //patrolSpeed = speed * 0.5f;
                if (myTransform.position.x >= wayPoint.x)
                {
                    myTransform.localRotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    myTransform.localRotation = Quaternion.Euler(0, 0, 0);
                }

                //判斷是否到了隨機巡邏點
                if (Vector3.Distance(wayPoint, transform.position) <= stoppingDistance)
                {
                    isChasing = false;
                    isIdle = true;
                    if (remainLookAtTime > 0)
                        remainLookAtTime -= Time.deltaTime;
                    else
                        GetNewWayPoint();
                }
                else
                {
                    isChasing = true;
                    isIdle = false;
                    transform.position = Vector3.MoveTowards(transform.position, wayPoint, patrolSpeed * Time.deltaTime);
                    if (leftFootCheck == false || rightFootCheck == false)
                    {
                        GetNewWayPoint();
                    }

                }
                break;
            case EnemyStates.CHASE:
                isChasing = true;
                isIdle = false;
                #region 翻面與追擊
                if (!FoundaPlayer())
                {
                    isChasing = false;
                    isIdle = true;
                    if (remainLookAtTime > 0)
                        remainLookAtTime -= Time.deltaTime;
                    else if (isIDLE)
                        enemyStates = EnemyStates.IDLE;
                    else
                        enemyStates = EnemyStates.PATROL;
                }
                else
                {
                    if (playerTransform && isHurt == false && isAttack == false)
                    {
                        if (myTransform.position.x >= playerTransform.position.x)
                        {
                            myTransform.localRotation = Quaternion.Euler(0, 180, 0);
                            if (leftFootCheck == false)
                            {
                                isChasing = false;
                                isIdle = true;
                                myTransform.position = this.transform.position;
                                rb.velocity = new Vector2(0, rb.velocity.y);
                            }
                            else
                            {
                                rb.velocity = new Vector2(-speed , rb.velocity.y);
                                /*myTransform.position -= new Vector3(speed * deltaTime, 0, 0);*/
                            }
                        }
                        else
                        {
                            myTransform.localRotation = Quaternion.Euler(0, 0, 0);
                            if (rightFootCheck == false)
                            {
                                isChasing = false;
                                isIdle = true;
                                myTransform.position = this.transform.position;
                                rb.velocity = new Vector2(0, rb.velocity.y);
                            }
                            else
                            {
                                rb.velocity = new Vector2(speed, rb.velocity.y);
                                /*myTransform.position += new Vector3(speed * deltaTime, 0, 0);*/
                            }

                        }
                    }
                }
                #endregion
                #region 進入攻擊範圍內進行攻擊
                if (TargetInAttackRange())
                {
                    isChasing = false;

                    rb.velocity = new Vector2(0, rb.velocity.y);
                    if (lastAttackTime < 0)
                    {
                        lastAttackTime = characterStats.attackData.coolDown;

                        //爆擊判斷
                        characterStats.isCritical = Random.value < characterStats.attackData.critcalChance;
                        //執行攻擊
                        Attack();
                    }
                }

                #endregion
                break;
            case EnemyStates.DEAD:
                rb.velocity = new Vector2(0, rb.velocity.y);

                Destroy(gameObject, 2f);
                break;
        }
    }

    bool TargetInAttackRange()
    {
        if (attackTarget != null)
        {
            return Vector3.Distance(attackTarget.transform.position, transform.position) <= characterStats.attackData.attackRange;
        }
        else
        {
            return false;
        }
    }

    void Attack()
    {
        Face();
        if (TargetInAttackRange())
        {
            //攻擊
            anim.SetTrigger("Attack");
            /*var targetStats = attackTarget.GetComponent<CharacterStats>();
            targetStats.TakeDamage(characterStats, targetStats);*/
        }
    }

    void Face()
    {
        if (myTransform.position.x >= playerTransform.position.x)
        {
            myTransform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            myTransform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    bool FoundaPlayer()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, sightRadius);

        foreach(var target in colliders)
        {
            if (target.CompareTag("Player"))
            {
                attackTarget = target.gameObject;
                return true;
            }
        }
        attackTarget = null;
        return false;
    }

    void GetNewWayPoint()
    {
        remainLookAtTime = lookAtTime;

        float randomX = Random.Range(-patrolRange, patrolRange);

        Vector3 randomPoint = new Vector3(idlePos.x + randomX, transform.position.y, transform.position.z);

        wayPoint = randomPoint;
    }



    #region 懸崖判斷
    void PhysicsCheck()
    {
        leftFootCheck = Raycast(new Vector2(-footOffset, footToGround), Vector2.down, groundDistance, groundLayer);
        rightFootCheck = Raycast(new Vector2(footOffset, footToGround), Vector2.down, groundDistance, groundLayer);
        /*leftCheck = Raycast(new Vector2(-findPlayerX, findPlayerY), Vector2.left, playerDistance, playerLayer);
        rightCheck = Raycast(new Vector2(findPlayerX, findPlayerY), Vector2.right, playerDistance, playerLayer);*/
    }

    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDiraction, float length, LayerMask layer)
    {
        Vector2 pos = transform.position;
        //Debug.Log(pos);
        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDiraction, length, layer);
        Color color = hit ? Color.red : Color.green;

        Debug.DrawRay(pos + offset, rayDiraction * length, color);

        return hit;
    }
    #endregion

    #region 畫圓
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, patrolRange);
    }

    public void EndNotify()
    {
        playerDead = true;
        isChasing = false;
        isAttack = false;
        isIdle = false;
        attackTarget = null;
    }
    #endregion
}
