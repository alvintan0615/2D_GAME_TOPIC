using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Tori : MonoBehaviour
{
    public static Boss_Tori instance;
    [SerializeField] Transform player;
    [SerializeField] float angle;
    [SerializeField] CharacterStats characterStats;
    public bool isSewer;
    public bool isTimeLineOK;
    public int hurtToTimeLine;
    [Header("Idle")]
    [SerializeField] float groundToFlyingMoveSpeed;
    [SerializeField] Vector2 groundToFlyingMoveDirection;

    [Header("Fly")]
    [SerializeField] float flyMoveSpeed;
    [SerializeField] Vector2 flyMoveDirection;

    [Header("SprayFire")]
    [SerializeField] float SprayFireMoveSpeed;
    [SerializeField] GameObject sprayFirePrefab;
    [Header("windAttack")]
    [SerializeField] float windAttackMoveSpeed;
    [SerializeField] Transform windPos1;
    [SerializeField] Transform windPos2;
    [SerializeField] Transform windPos3;
    [SerializeField] GameObject windPrefab;

    [Header("diveAttack")]
    [SerializeField] float diveAttackMoveSpeed;
    private Vector2 playerPosition;
    private bool hasPlayerPosition;
    [Header("PhysicsCheck")]
    [SerializeField] Transform groundCheckDown;
    [SerializeField] Transform groundCheckUp;
    [SerializeField] Transform groundCheckWall;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundlayer;
    [SerializeField] LayerMask walllayer;
    private bool isTouchingUp;
    private bool isTouchingDown;
    private bool isTouchingWall;
    private Rigidbody2D rb;

    [Header("Injury")]
    [SerializeField]private SpriteRenderer spriteRenderer;

    [Header("Dizzy")]
    [SerializeField] int changeColorTime;
    public bool isDead = false;

    [Header("Other")]
    public Animator anim;
    public bool facingLeft = true;
    private float naturalGravity;
    [SerializeField] private int randomFlip;

    void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        characterStats.CurrentHealth = characterStats.MaxHealth;
        if (isSewer == true)
            flyMoveDirection.x = 1;
    }

    void Start()
    {
        characterStats = GetComponent<CharacterStats>();
        groundToFlyingMoveDirection.Normalize();
        flyMoveDirection.Normalize();
        player = FindObjectOfType<NewPlayerController>().transform;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        naturalGravity = rb.gravityScale;
        windPos1 = transform.GetChild(3);
        windPos2 = transform.GetChild(4);
        windPos3 = transform.GetChild(5);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        physicsCheck();

        /*if (Input.GetKeyDown(KeyCode.P))
            SpawnBigWind();*/

        angle = Vector3.Angle(transform.position, player.position);

        DizzyTime();

        if (EventManager.Instance.fireVillege_TimelineChangeDemon == true)
            characterStats.CurrentDefence = 5;

        if(EventManager.Instance.Sewer_TimeLineBossTori == true && PlayerStatus.isDialouging == false)
        {
            isTimeLineOK = true;
        }

        anim.SetBool("isTimeLineOK", isTimeLineOK);

        if(isSewer == true && characterStats.CurrentHealth <= 0)
        {
            isDead = true;
            rb.gravityScale = 0f;
            anim.SetBool("isDead", true);
        }
    }

    void RandomStatePicker()
    {
        int randomState = Random.Range(0, 3);
        if(PlayerStatus.isDialouging == false )
        {
            if (randomState == 0)
                anim.SetTrigger("DiveAttack");
            else if (randomState == 1)
                anim.SetTrigger("FlyWindAttack");
            else if (randomState == 2)
                anim.SetTrigger("SprayFire");
        }
        
    }

    void GroundRandomStatePicker()
    {
        int randomState = Random.Range(0, 3);
        if(PlayerStatus.isDialouging == false && isSewer == true)
        {
            if (randomState == 0)
                anim.SetTrigger("GroundSprayFire");
            else if (randomState >= 1)
                anim.SetTrigger("GroundToFly");
        }
    }

    public void GroundIdle()
    {
        FlipTowardsPlayer();
        rb.velocity = Vector2.zero;
        anim.SetBool("ToFlyIdle", false);
    }

    public void FlyIdle()
    {
        FlipTowardsPlayer();
        //sprayFirePrefab.SetActive(false);
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(0, 0);
        anim.SetBool("ToFlyIdle", false);
    }

    public void Fly()
    {
        rb.velocity = flyMoveSpeed * flyMoveDirection;
        if (isTouchingWall)// || randomFlip >= 45
        {
            if (facingLeft)
                flip();
            else
                flip();
            
        }
        //randomFlip = 0;
        
    }

    public void GroundToFlyIdle()
    {
        if (isTouchingUp == false)
        {
            rb.velocity = groundToFlyingMoveSpeed * groundToFlyingMoveDirection;
            rb.gravityScale = naturalGravity;
        }
        else if(isTouchingUp == true)
        {
            //TODO SetAnimTrigger To FlyIdle
            anim.SetBool("ToFlyIdle", true);
        }
    }

    /*public void FlyWindAttack()
    {
        int randomSpawn = Random.Range(3, 5);
        InvokeRepeating("SpawnWind", randomSpawn, 0.1f);
    }*/

    public void SprayFireOn()
    {
        rb.velocity = (flyMoveSpeed * flyMoveDirection)/1.3f;
        if (isTouchingWall) 
        {
            flip();
        }
        //TODO 噴火特效

    }
    public void SprayFireOff()
    {
        rb.velocity = flyMoveSpeed * flyMoveDirection / 2;
        //TODO 噴火特效
        //sprayFirePrefab.SetActive(false);
    }

    void RandomFlyFlip()
    {
        randomFlip = Random.Range(1, 50);
    }

    void SpawnBigWind()
    {
        float playerDirection = player.position.x - transform.position.x;
        if (playerDirection > 0)
            Instantiate(windPrefab, new Vector3(player.position.x - 15 , -26.5f), Quaternion.identity);
        else if(playerDirection < 0)
            Instantiate(windPrefab, new Vector3(player.position.x + 15, -26.5f), Quaternion.identity);

        /*Instantiate(windPrefab, windPos2.position, Quaternion.identity);
        Instantiate(windPrefab, windPos3.position, Quaternion.identity);*/
    }

    void SpawnBigWindinSewer()
    {
        float playerDirection = player.position.x - transform.position.x;
        if (playerDirection > 0)
            Instantiate(windPrefab, new Vector3(player.position.x - 15, 63.4f), Quaternion.identity);
        else if (playerDirection < 0)
            Instantiate(windPrefab, new Vector3(player.position.x + 15, 63.4f), Quaternion.identity);

        /*Instantiate(windPrefab, windPos2.position, Quaternion.identity);
        Instantiate(windPrefab, windPos3.position, Quaternion.identity);*/
    }

    public void DiveAttack()
    {
        if (!hasPlayerPosition)
        {
            playerPosition = player.position - transform.position;
            playerPosition.Normalize();
            hasPlayerPosition = true;
        }
        if (hasPlayerPosition)
        {
            rb.gravityScale = naturalGravity;
            rb.velocity = playerPosition * diveAttackMoveSpeed;
        }  
        if(isTouchingDown) //isTouchingWall || 
        {
            rb.velocity = Vector2.zero;
            hasPlayerPosition = false;
            anim.SetTrigger("DiveAttackToGround");
        }
        if (isTouchingWall)
        {
            rb.velocity = Vector2.zero;
            hasPlayerPosition = false;
            anim.SetTrigger("DiveToAir");
        }
    }

    public void Dizzy()
    {
        rb.gravityScale = naturalGravity;
        rb.velocity = new Vector2(0, -20);
        if (isTouchingDown)
        {
            anim.SetTrigger("DizzyToGround");
        }
    }

    public void DizzyTime()
    {
        if (changeColorTime >=20)
        {
            anim.SetTrigger("Dizzy");
            changeColorTime = 0;
        }
    }

    void FlipTowardsPlayer()
    {
        float playerDirection = player.position.x - transform.position.x;

        if (playerDirection > 0 && facingLeft)
            flip();
        else if (playerDirection < 0 && !facingLeft)
            flip();
    }

    public void AboutToAttack()
    {
        rb.velocity = new Vector2(0, 0);
        FlipTowardsPlayer();
        
    }

    public void Injury()
    {
        StartCoroutine(ChangeColor(new Color(1f, 0.39f, 0.37f), 0.1f));
    }

    void flip()
    {
        facingLeft = !facingLeft;
        flyMoveDirection.x *= -1;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

    void physicsCheck()
    {
        isTouchingUp = Physics2D.OverlapCircle(groundCheckUp.position, groundCheckRadius, groundlayer);
        isTouchingDown = Physics2D.OverlapCircle(groundCheckDown.position, groundCheckRadius, groundlayer);
        isTouchingWall = Physics2D.OverlapCircle(groundCheckWall.position, groundCheckRadius, walllayer);
    }

    IEnumerator ChangeColor(Color color , float colorChangeTime)
    {
        spriteRenderer.color = color;
        changeColorTime += 1;
        yield return new WaitForSeconds(colorChangeTime);

        spriteRenderer.color = new Color(1, 1, 1);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheckUp.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckDown.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckWall.position, groundCheckRadius);
    }
}
