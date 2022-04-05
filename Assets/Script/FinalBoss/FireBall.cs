using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject meteorHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            FireBallHitObjectpool.instance.FireBallHitGetFromPool(this.gameObject.transform.position);
            FireBallObjectpool.instance.FireBallReturnPool(this.gameObject);
        }
        if(collision.gameObject.layer == 8)
        {
            FireBallHitObjectpool.instance.FireBallHitGetFromPool(this.gameObject.transform.position);
            FireBallObjectpool.instance.FireBallReturnPool(this.gameObject);
        }
    }
}
