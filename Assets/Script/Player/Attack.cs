using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public static bool isDamage = false;
    private void Awake()
    {
        
    }
    private void Update()
    {
        
    }
    void Damage()
    {
        PlayerController.instance.Damage();
        /*Collider2D[] enemyColList = new Collider2D[3];

        enemyCount = PlayerController.attackTrigger.OverlapCollider(PlayerController.enemyFilter, enemyColList);
        Debug.Log(enemyCount);

        if (enemyCount > 0)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                var enemyStats = enemyColList[i].GetComponent<CharacterStats>();
                enemyStats.TakeDamage(PlayerController.characterStats, enemyStats);
            }
        }*/

    }
}
