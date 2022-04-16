using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallHit : MonoBehaviour
{

    private void Awake()
    {
        
    }
    private void OnEnable()
    {

        //Dust Audio play
        StartCoroutine(ReturnPool());
    }

    IEnumerator ReturnPool()
    {
        yield return new WaitForSeconds(1.5f);
        //Dust Audio Mute
        FireBallHitObjectpool.instance.FireBallHitReturnPool(this.gameObject);
    }
}
