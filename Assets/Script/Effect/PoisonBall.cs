using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBall : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PoisonBallObjcetPool.instance.PoisonBallReturnPool(this.gameObject);
            PoisonContainerObjectPool.instance.PoisonContainerGetFromPool(this.gameObject.transform.position);
        }

        if (collision.gameObject.layer == 8)
        {
            PoisonBallObjcetPool.instance.PoisonBallReturnPool(this.gameObject);
            PoisonContainerObjectPool.instance.PoisonContainerGetFromPool(this.gameObject.transform.position);
        }
    }
}
