using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallHitObjectpool : MonoBehaviour
{
    public static FireBallHitObjectpool instance;

    public GameObject fireBallHitPrefab;

    public int fireBallHitCount;

    private Queue<GameObject> fireBallHitAvailableObjects = new Queue<GameObject>();
    void Awake()
    {
        instance = this;
        FireBallHitFillpool();
    }

    // Update is called once per frame
    public void FireBallHitFillpool()
    {
        for (int i = 0; i < fireBallHitCount; i++)
        {
            var newFireBallHit = Instantiate(fireBallHitPrefab);
            newFireBallHit.transform.SetParent(transform);
            fireBallHitAvailableObjects.Enqueue(newFireBallHit);
            newFireBallHit.SetActive(false);
        }
    }

    public void FireBallHitReturnPool(GameObject gameObject)
    {
        gameObject.SetActive(false);

        fireBallHitAvailableObjects.Enqueue(gameObject);
    }

    public GameObject FireBallHitGetFromPool(Vector3 fireBallHitPos)
    {
        if (fireBallHitAvailableObjects.Count == 0)
        {
            FireBallHitFillpool();
        }

        var outFireBallHit = fireBallHitAvailableObjects.Dequeue();

        outFireBallHit.SetActive(true);

        outFireBallHit.transform.position = fireBallHitPos;

        return outFireBallHit;
    }
}
