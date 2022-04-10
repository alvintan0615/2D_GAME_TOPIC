using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject meteorHit;
    public GameObject target;
    public GameObject player;

    void OnEnable()
    {
        target = GameObject.FindGameObjectWithTag("FinalBoss_FirstPart");
        player = GameObject.FindGameObjectWithTag("Player");
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            FireBallHitObjectpool.instance.FireBallHitGetFromPool(this.gameObject.transform.position);
            FireBallObjectpool.instance.FireBallReturnPool(this.gameObject);
            var bossStats = target.GetComponent<CharacterStats>();
            var playerStats = player.GetComponent<CharacterStats>();
            playerStats.TakeDamage(bossStats, playerStats, 0);
        }
        if(collision.gameObject.layer == 8)
        {
            FireBallHitObjectpool.instance.FireBallHitGetFromPool(this.gameObject.transform.position);
            FireBallObjectpool.instance.FireBallReturnPool(this.gameObject);
        }
    }
}
