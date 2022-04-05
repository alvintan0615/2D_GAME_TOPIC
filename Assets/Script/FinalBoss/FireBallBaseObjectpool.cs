using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBaseObjectpool : MonoBehaviour
{
    public static FireBallBaseObjectpool instance;

    public GameObject fireBallBasePrefab;

    public int fireBallBaseCount;

    private Queue<GameObject> fireBallBaseAvailableObjects = new Queue<GameObject>();
    void Awake()
    {
        instance = this;
        FireBallBaseFillpool();
    }

    // Update is called once per frame
    public void FireBallBaseFillpool()
    {
        for (int i = 0; i < fireBallBaseCount; i++)
        {
            var newFireBallBase = Instantiate(fireBallBasePrefab);
            newFireBallBase.transform.SetParent(transform);
            fireBallBaseAvailableObjects.Enqueue(newFireBallBase);
            newFireBallBase.SetActive(false);
        }
    }

    public void FireBallBaseReturnPool(GameObject gameObject)
    {
        gameObject.SetActive(false);

        fireBallBaseAvailableObjects.Enqueue(gameObject);
    }

    public GameObject FireBallBaseGetFromPool(Vector3 fireBallBasePos)
    {
        if (fireBallBaseAvailableObjects.Count == 0)
        {
            FireBallBaseFillpool();
        }

        var outFireBallBase = fireBallBaseAvailableObjects.Dequeue();

        outFireBallBase.SetActive(true);

        outFireBallBase.transform.position = fireBallBasePos;

        return outFireBallBase;
    }
}
