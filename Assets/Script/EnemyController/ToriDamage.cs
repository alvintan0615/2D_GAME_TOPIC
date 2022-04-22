using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToriDamage : MonoBehaviour
{
    [SerializeField] CharacterStats characterStats;
    [SerializeField] Boss_Tori boss_Tori;
    [Header("攻擊判斷")]
    [SerializeField] private BoxCollider2D attackTrigger;
    [SerializeField] private ContactFilter2D playerFilter;
    [SerializeField] private int playerCount;
    [SerializeField] private Collider2D[] playerColList;
    private void Awake()
    {
        attackTrigger = transform.GetChild(7).GetComponent<BoxCollider2D>();
        playerFilter.SetLayerMask(LayerMask.GetMask("Player"));

        characterStats = GetComponent<CharacterStats>();
        boss_Tori = GetComponent<Boss_Tori>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToriDiveAttackDamage()
    {
        playerColList = new Collider2D[1];
        playerCount = attackTrigger.OverlapCollider(playerFilter, playerColList);
        if(boss_Tori.isSewer == false)
        {
            if (playerCount > 0 && PlayerStatus.canBeHurt == true)
            {
                for (int i = 0; i < playerCount; i++)
                {
                    boss_Tori.hurtToTimeLine += 1;
                    var playerStats = playerColList[i].GetComponent<CharacterStats>();
                    playerStats.TakeDamage(characterStats, playerStats, 20);
                }
            }
        }

        if(boss_Tori.isSewer == true)
        {
            if (playerCount > 0 && PlayerStatus.canBeHurt == true)
            {
                for (int i = 0; i < playerCount; i++)
                {
                    var playerStats = playerColList[i].GetComponent<CharacterStats>();
                    playerStats.TakeDamage(characterStats, playerStats, 10);
                }
            }
        }
        
    }

    public void ToriSprayFireDamage()
    {
        playerColList = new Collider2D[1];
        playerCount = attackTrigger.OverlapCollider(playerFilter, playerColList);

        if (boss_Tori.isSewer == false)
        {
            if (playerCount > 0 && PlayerStatus.canBeHurt == true)
            {
                for (int i = 0; i < playerCount; i++)
                {
                    boss_Tori.hurtToTimeLine += 1;
                    var playerStats = playerColList[i].GetComponent<CharacterStats>();
                    playerStats.TakeDamage(characterStats, playerStats, 10);
                }
            }
        }

        if (boss_Tori.isSewer == true)
        {
            if (playerCount > 0 && PlayerStatus.canBeHurt == true)
            {
                for (int i = 0; i < playerCount; i++)
                {
                    var playerStats = playerColList[i].GetComponent<CharacterStats>();
                    playerStats.TakeDamage(characterStats, playerStats, 6);
                }
            }
        }
    }
}
