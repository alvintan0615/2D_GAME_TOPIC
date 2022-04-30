using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss_SecondPart_TakeDamage : MonoBehaviour
{
    [SerializeField] CharacterStats characterStats;
    [Header("攻擊判斷")]
    [SerializeField] private BoxCollider2D attackTrigger;
    [SerializeField] private ContactFilter2D playerFilter;
    [SerializeField] private int playerCount;
    [SerializeField] private Collider2D[] playerColList;
    private void Awake()
    {
        attackTrigger = transform.GetChild(0).GetComponent<BoxCollider2D>();
        playerFilter.SetLayerMask(LayerMask.GetMask("Player"));

        characterStats = GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseAttackDamage()
    {
        playerColList = new Collider2D[1];
        playerCount = attackTrigger.OverlapCollider(playerFilter, playerColList);

        if (playerCount > 0 && PlayerStatus.canBeHurt == true)
        {
            for (int i = 0; i < playerCount; i++)
            {
                var playerStats = playerColList[i].GetComponent<CharacterStats>();
                playerStats.TakeDamage(characterStats, playerStats, 15);
            }
        }
    }
}
