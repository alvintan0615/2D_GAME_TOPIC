using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBase : MonoBehaviour
{
    public GameObject fireBall;
    void Start()
    {
        InvokeRepeating("CreateFireBall", 2.5f, 10);
    }

    void Update()
    {
        StartCoroutine(destoryBase());
    }

    void CreateFireBall()
    {
        Instantiate(fireBall, new Vector3(this.gameObject.transform.position.x, 11.12f), Quaternion.identity);
    }

    IEnumerator destoryBase()
    {
        yield return new WaitForSeconds(3.5f);
        Destroy(this.gameObject);
    }
}
