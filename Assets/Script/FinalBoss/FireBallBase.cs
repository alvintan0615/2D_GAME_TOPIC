using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBase : MonoBehaviour
{
    public GameObject fireBall;

    void OnEnable()
    {
        StartCoroutine(CreateFireBall());
    }

    void Update()
    {
        StartCoroutine(ReturnBase());
    }

    /*void CreateFireBall()
    {
        FireBallObjectpool.instance.FireBallGetFromPool(new Vector3(this.gameObject.transform.position.x, 11.12f));
    }*/

    IEnumerator CreateFireBall()
    {
        yield return new WaitForSeconds(2.5f);
        FireBallObjectpool.instance.FireBallGetFromPool(new Vector3(this.gameObject.transform.position.x, 11.12f));
    }

    IEnumerator ReturnBase()
    {
        yield return new WaitForSeconds(3.5f);
        FireBallBaseObjectpool.instance.FireBallBaseReturnPool(this.gameObject);
    }
}
