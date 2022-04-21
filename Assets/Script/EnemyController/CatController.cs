using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CatEnemyStates { IDLE, CHASE, PATROL, DEAD }
public class CatController : MonoBehaviour, IEndGameObserver
{
    public CatEnemyStates catEnemyStates;
    private CharacterStats characterStats;
    public Rigidbody2D rb;
    private Animator anim;
    bool playerDead;
    public bool isFaceRight = true;
    [Header("Basic Settings")]
    public float sightRadius;
    public float speed;
    public float patrolSpeed;
    private Transform myTransform;
    private Transform playerTransform;
    public float lookAtTime;
    private float remainLookAtTime;
    [SerializeField]private float lastAttackTime;
    public bool isIDLE;
    public bool isHurt = false;
    public bool isAttack = false;
    private Color color;
    private SpriteRenderer spriteRenderer;

    [Header("environmental Check")]
    public float footOffset = 1.8f;
    public float groundDistance = 1f;
    public float footToGround = 0f;
    public LayerMask groundLayer;
    private RaycastHit2D leftFootCheck;
    private RaycastHit2D rightFootCheck;


    [Header("Animation Settings")]
    [SerializeField] private bool isIdle;
    [SerializeField] private bool isChasing;

    [Header("PATROL States")]
    public float stoppingDistance;
    public float patrolRange;
    [SerializeField] private Vector3 wayPoint;
    [SerializeField] private Vector3 idlePos;

    [SerializeField]private bool isDead;
    private GameObject attackTarget;
    void Start()
    {
        characterStats = GetComponent<CharacterStats>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        remainLookAtTime = lookAtTime;

        myTransform = this.transform;
        idlePos = this.gameObject.transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (isIDLE)
        {
            catEnemyStates = CatEnemyStates.IDLE;
        }
        else
        {
            catEnemyStates = CatEnemyStates.PATROL;
            GetNewWayPoint();
        }


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

    void Update()
    {
        if (characterStats.CurrentHealth <= 0)
            isDead = true;

        if (isDead == true)
            catEnemyStates = CatEnemyStates.DEAD;

        if (foundPlayer() && leftFootCheck == true && rightFootCheck == true && isDead == false)
        {
            catEnemyStates = CatEnemyStates.CHASE;
        }

        if ((!foundPlayer() || leftFootCheck == false || rightFootCheck == false) && isDead == false)
        {
            catEnemyStates = CatEnemyStates.PATROL;
            //GetNewWayPoint();
        }

        if (!playerDead)
        {
            SwitchStates();
            SwitchAnimation();
            lastAttackTime -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        PhysicsCheck();
    }

    void SwitchAnimation()
    {
        anim.SetBool("Idle", isIdle);
        anim.SetBool("Chasing", isChasing);

    }

    void SwitchStates()
    {
        switch (catEnemyStates)
        {
            case CatEnemyStates.IDLE:
                isIdle = true;
                break;
            case CatEnemyStates.PATROL:
                if(isAttack == false && isDead == false)
                {
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
                    }
                }
                
                break;
            case CatEnemyStates.CHASE:
                isChasing = true;
                isIdle = false;
                if (!foundPlayer())
                {
                    isChasing = false;
                    isIdle = true;
                    if (remainLookAtTime > 0)
                        remainLookAtTime -= Time.deltaTime;
                    else if (isIDLE)
                        catEnemyStates = CatEnemyStates.IDLE;
                    else
                        catEnemyStates = CatEnemyStates.PATROL;
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
                if (TargetInAttackRange() && isDead == false)
                {
                    isChasing = false;

                    rb.velocity = new Vector2(0, rb.velocity.y);
                    if (lastAttackTime < 0)
                    {
                        anim.SetBool("Idle", false);
                        lastAttackTime = characterStats.attackData.coolDown;
                        //執行攻擊
                        Attack();
                    }
                    if(lastAttackTime > 0 && isAttack == true)
                    {
                        //catEnemyStates = CatEnemyStates.PATROL;
                        isIdle = true;
                        isChasing = false;
                    }
                        
                }
                break;

            case CatEnemyStates.DEAD:
                anim.SetBool("Dead", true);
                isChasing = false;
                rb.velocity = new Vector2(0, rb.velocity.y);

                Destroy(gameObject, 2f);
                break;
        }
    }
    void GetNewWayPoint()
    {
        remainLookAtTime = lookAtTime;

        float randomX = Random.Range(-patrolRange, patrolRange);
        Vector3 randomPoint = new Vector3(idlePos.x + randomX, transform.position.y, transform.position.z);
        wayPoint = randomPoint;
    }

    void Attack()
    {
        Face();
        if (TargetInAttackRange())
        {
            //攻擊
            anim.SetTrigger("PoisonAttack");
            /*var targetStats = attackTarget.GetComponent<CharacterStats>();
            targetStats.TakeDamage(characterStats, targetStats);*/
        }
    }

    void Face()
    {
        if (myTransform.position.x >= playerTransform.position.x)
        {
            isFaceRight = false;
            myTransform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            isFaceRight = true;
            myTransform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    bool TargetInAttackRange()
    {
        if (attackTarget != null)
        {
            return Vector3.Distance(attackTarget.transform.position, transform.position) <= sightRadius;
        }
        else
        {
            return false;
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

    public void InjuryHurt()
    {
        StartCoroutine(ChangeColor(new Color(1f, 0.39f, 0.37f), 0.1f));
    }

    IEnumerator ChangeColor(Color color, float colorChangeTime)
    {
        spriteRenderer.color = color;
        yield return new WaitForSeconds(colorChangeTime);
        spriteRenderer.color = new Color(1, 1, 1);
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
    }

    public void AgainNotify()
    {
        playerDead = false;
    }

}
