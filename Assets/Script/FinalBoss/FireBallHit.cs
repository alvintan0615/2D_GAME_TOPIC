using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallHit : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(ReturnPool());
    }

    IEnumerator ReturnPool()
    {
        yield return new WaitForSeconds(1.5f);
        FireBallHitObjectpool.instance.FireBallHitReturnPool(this.gameObject);
    }
}
