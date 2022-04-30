using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWind : MonoBehaviour
{
    private Rigidbody2D rb;
    private float naturalGravity;
    private Boss_Tori tori;
    private Transform player;
    private float playerDirection;
    CharacterStats toriCharacterStats;
    [SerializeField] Vector2 windDir;
    [SerializeField] float windSpeed;

    [Header("WindAttack")]
    [SerializeField] private BoxCollider2D attackTrigger;
    [SerializeField] private ContactFilter2D playerFilter;
    [SerializeField] private int playerCount;
    [SerializeField] private Collider2D[] playerColList;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tori = GameObject.FindGameObjectWithTag("Tori").GetComponent<Boss_Tori>();
        player = FindObjectOfType<NewPlayerController>().transform;
        naturalGravity = rb.gravityScale;
        windDir.Normalize();

        attackTrigger = GetComponent<BoxCollider2D>();
        playerFilter.SetLayerMask(LayerMask.GetMask("Player"));
        toriCharacterStats = GameObject.FindGameObjectWithTag("Tori").GetComponent<CharacterStats>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        StartCoroutine(BigWindAttack());
    }

    void DecideLR()
    {
        playerDirection = player.position.x - transform.position.x;
    }

    void WindAttack()
    {
        playerColList = new Collider2D[1];
        playerCount = attackTrigger.OverlapCollider(playerFilter, playerColList);

        if (playerCount > 0 && PlayerStatus.canBeHurt == true && PlayerStatus.isHurting == false)
        {
            for (int i = 0; i < playerCount; i++)
            {
                var playerStats = playerColList[i].GetComponent<CharacterStats>();
                playerStats.TakeDamage(toriCharacterStats, playerStats, 7);
            }
        }
    }

    IEnumerator BigWindAttack()
    {
        rb.gravityScale = 0f;
        yield return new WaitForSeconds(1f);
        if (playerDirection > 0)
        {
            rb.velocity = windSpeed * windDir;
        }
        else if (playerDirection < 0)
        {
            rb.velocity = windSpeed * -windDir;
        }
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
