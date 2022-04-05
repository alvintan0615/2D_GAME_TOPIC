using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallObjectpool : MonoBehaviour
{
    public static FireBallObjectpool instance;

    public GameObject fireBallPrefab;

    public int fireBallCount;

    private Queue<GameObject> fireBallAvailableObjects = new Queue<GameObject>();
    void Awake()
    {
        instance = this;
        FireBallFillpool();
    }

    // Update is called once per frame
    public void FireBallFillpool()
    {
        for (int i = 0; i < fireBallCount; i++)
        {
            var newFireBall = Instantiate(fireBallPrefab);
            newFireBall.transform.SetParent(transform);
            fireBallAvailableObjects.Enqueue(newFireBall);
            newFireBall.SetActive(false);
        }
    }

    public void FireBallReturnPool(GameObject gameObject)
    {
        gameObject.SetActive(false);

        fireBallAvailableObjects.Enqueue(gameObject);
    }

    public GameObject FireBallGetFromPool(Vector3 fireBallPos )
    {
        if(fireBallAvailableObjects.Count == 0)
        {
            FireBallFillpool();
        }

        var outFireBall = fireBallAvailableObjects.Dequeue();

        outFireBall.SetActive(true);

        outFireBall.transform.position = fireBallPos;

        return outFireBall;
    }
}
