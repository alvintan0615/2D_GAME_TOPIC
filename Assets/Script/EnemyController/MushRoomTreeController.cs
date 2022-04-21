using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MushRoomTreeEnemyStates { IDLE, CHASE, PATROL, DEAD }
public class MushRoomTreeController : MonoBehaviour, IEndGameObserver
{
    public MushRoomTreeEnemyStates mushRoomTreeEnemyStates;
    private CharacterStats characterStats;
    public Rigidbody2D rb;
    [SerializeField]private Animator anim;
    public bool isAttack = false;
    bool playerDead;

    public bool isDarkTree;
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
    public float knockbackForce;
    public bool isHurt;

    [Header("FarAttack Settings")]
    bool isfarAttack = false;
    private GameObject farAttackTarget;
    public GameObject thorn;
    public float farAttackRadius;

    [Header("Animation Settings")]
    [SerializeField]private bool isIdle;
    [SerializeField]private bool isChasing;

    private bool isDead;
    [Header("PATROL States")]
    public float stoppingDistance;
    public float patrolRange;
    private Vector3 wayPoint;
    private Vector3 idlePos;
    public bool delayTrans = true;
    public float x = 1f;
    void Start()
    {
        characterStats = GetComponent<CharacterStats>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        idlePos = transform.position;
        remainLookAtTime = lookAtTime;

        if (isIDLE)
        {
            mushRoomTreeEnemyStates = MushRoomTreeEnemyStates.IDLE;
        }
        else
        {
            mushRoomTreeEnemyStates = MushRoomTreeEnemyStates.PATROL;
            GetNewWayPoint();
        }

        myTransform = this.transform;
        if (GameObject.FindWithTag("Player") != null)
        {
            playerTransform = GameObject.FindWithTag("Player").transform;
        }
        GameManager.Instance.AddObserver(this);
    }

    void OnDisable()
    {
        if (!GameManager.IsInitialized) return;
        GameManager.Instance.RemoveObserver(this);
    }

    private void FixedUpdate()
    {
        PhysicsCheck();
    }

    void Update()
    {
        if (characterStats.CurrentHealth <= 0)
            isDead = true;
        if (!playerDead)
        {
            SwitchStates();
            SwitchAnimation();
            lastAttackTime -= Time.deltaTime;
        }

        if (isDead)
            mushRoomTreeEnemyStates = MushRoomTreeEnemyStates.DEAD;
        else if (foundPlayer() && leftFootCheck == true && rightFootCheck == true )
        {
            mushRoomTreeEnemyStates = MushRoomTreeEnemyStates.CHASE;
            x = 1f;
        }
        else if(isHurt == false)
        {
            delayTrans = false;
            mushRoomTreeEnemyStates = MushRoomTreeEnemyStates.PATROL;
            x -= Time.deltaTime;
            if (x  <= 0f)
                delayTrans = true;
        }

        
    }

    void SwitchAnimation()
    {
        anim.SetBool("Idle", isIdle);
        anim.SetBool("Chasing", isChasing);
        
    }

    void SwitchStates()
    {
        switch (mushRoomTreeEnemyStates)
        {
            case MushRoomTreeEnemyStates.IDLE:
                isIdle = true;
                break;
            case MushRoomTreeEnemyStates.PATROL:

                if(isDarkTree == true && foundPlayer() == false && farAttackFoundPlayer() == true)
                {
                    if(lastAttackTime < 0)
                    {
                        lastAttackTime = characterStats.attackData.coolDown01;
                        anim.SetTrigger("FarAttack");
                    }
                } 
                if(isAttack == false)
                {
                    //patrolSpeed = speed * 0.5f;
                    if (myTransform.position.x >= wayPoint.x)
                    {
                        myTransform.localRotation = Quaternion.Euler(0, 180, 0);
                    }
                    else
                    {
                        myTransform.localRotation = Quaternion.Euler(0, 0, 0);
                    }

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
                        /*if (leftFootCheck == false || rightFootCheck == false)
                        {
                            GetNewWayPoint();
                        }*/

                    }
                }
                
                break;
            case MushRoomTreeEnemyStates.CHASE:
                isChasing = true;
                isIdle = false;
                if (!foundPlayer())
                {
                    isChasing = false;
                    isIdle = true;
                    if (remainLookAtTime > 0)
                        remainLookAtTime -= Time.deltaTime;
                    else if (isIDLE)
                        mushRoomTreeEnemyStates = MushRoomTreeEnemyStates.IDLE;
                    else
                        mushRoomTreeEnemyStates = MushRoomTreeEnemyStates.PATROL;
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
                            rb.velocity = new Vector2(-speed, rb.velocity.y);
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
                if (TargetInAttackRange())
                {
                    isChasing = false;

                    rb.velocity = new Vector2(0, rb.velocity.y);
                    if (lastAttackTime < 0)
                    {
                        anim.SetBool("Idle", false);
                        lastAttackTime = characterStats.attackData.coolDown;

                        //爆擊判斷
                        characterStats.isCritical = Random.value < characterStats.attackData.critcalChance;
                        //執行攻擊
                        Attack();
                    }
                    else
                        anim.SetBool("Idle", true);
                }
                break;

            case MushRoomTreeEnemyStates.DEAD:
                anim.SetBool("Dead", true);
                isChasing = false;
                rb.velocity = new Vector2(0, rb.velocity.y);

                Destroy(gameObject, 2f);
                break;
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

    bool foundPlayer()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, sightRadius);

        foreach (var target in colliders)
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

    bool farAttackFoundPlayer()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, farAttackRadius);

        foreach (var target in colliders)
        {
            if (target.CompareTag("Player"))
            {
                farAttackTarget = target.gameObject;
                return true;
            }
        }
        farAttackTarget = null;
        return false;
    }

    void farAttack()
    {
        Instantiate(thorn, farAttackTarget.transform.position, transform.rotation);
    }

    void GetNewWayPoint()
    {
        remainLookAtTime = lookAtTime;

        float randomX = Random.Range(-patrolRange, patrolRange);

        Vector3 randomPoint = new Vector3(idlePos.x + randomX, transform.position.y, transform.position.z);

        wayPoint = randomPoint;
    }

    void PhysicsCheck()
    {
        leftFootCheck = Raycast(new Vector2(-footOffset, footToGround), Vector2.down, groundDistance, groundLayer);
        rightFootCheck = Raycast(new Vector2(footOffset, footToGround), Vector2.down, groundDistance, groundLayer);
    }

    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDiraction, float length, LayerMask layer)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDiraction, length, layer);
        Color color = hit ? Color.red : Color.green;

        Debug.DrawRay(pos + offset, rayDiraction * length, color);

        return hit;
    }

    IEnumerator delayTRANS()
    {
        delayTrans = false;
        yield return new WaitForSeconds(1f);
        delayTrans = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, patrolRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, farAttackRadius);
    }

    public void EndNotify()
    {
        playerDead = true;
        isChasing = false;
        isAttack = false;
        isIdle = false;
    }

    public void AgainNotify()
    {
        playerDead = false;
    }
}
