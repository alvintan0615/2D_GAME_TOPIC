using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonDamage : MonoBehaviour
{
    [SerializeField] CharacterStats characterStats;
    [Header("攻擊判斷")]
    [SerializeField] private BoxCollider2D newAttackTrigger;
    [SerializeField] private ContactFilter2D enemyFilter;
    [SerializeField] private int enemyCount;
    [SerializeField] private Collider2D[] enemyColList;
    private void Awake()
    {
        newAttackTrigger = transform.GetChild(0).GetComponent<BoxCollider2D>();
        enemyFilter.SetLayerMask(LayerMask.GetMask("Enemy"));

        characterStats = transform.GetComponentInParent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NormalAttackDamage()
    {
        enemyColList = new Collider2D[3];
        enemyCount = newAttackTrigger.OverlapCollider(enemyFilter, enemyColList);

        if (enemyCount > 0)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                var enemyStats = enemyColList[i].GetComponent<CharacterStats>();
                enemyStats.TakeDamage(characterStats, enemyStats, 4);

            }
        }
    }

    public void BeamSkillDamage()
    {
        enemyColList = new Collider2D[7];
        enemyCount = newAttackTrigger.OverlapCollider(enemyFilter, enemyColList);

        if (enemyCount > 0)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                var enemyStats = enemyColList[i].GetComponent<CharacterStats>();
                enemyStats.TakeDamage(characterStats, enemyStats, 6);

            }
        }
    }

    public void AllScreenSkillDamage()
    {
        enemyColList = new Collider2D[5];
        enemyCount = newAttackTrigger.OverlapCollider(enemyFilter, enemyColList);

        if (enemyCount > 0)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                var enemyStats = enemyColList[i].GetComponent<CharacterStats>();
                enemyStats.TakeDamage(characterStats, enemyStats, 9);

            }
        }
    }
}
