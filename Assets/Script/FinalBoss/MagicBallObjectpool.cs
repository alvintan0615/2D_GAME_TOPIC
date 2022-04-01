using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBallObjectpool : MonoBehaviour
{
    public static MagicBallObjectpool instance;

    public GameObject magicBallPrefab;

    public int magicBallCount;

    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    void Awake()
    {
        instance = this;
    }

    public void Fillpool()
    {
        for (int i = 0; i < magicBallCount; i++)
        {
            var newMagicBall = Instantiate(magicBallPrefab);
            newMagicBall.transform.SetParent(transform);

            
        }
    }

    public void ReturnPool(GameObject gameObject)
    {
        gameObject.SetActive(false);

        availableObjects.Enqueue(gameObject);
    }

    public GameObject GetFromPool()
    {
        var outMagicBall = availableObjects.Dequeue();

        outMagicBall.SetActive(true);

        return outMagicBall;
    }

}
