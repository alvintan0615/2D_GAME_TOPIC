using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonContainerObjectPool : MonoBehaviour
{
    public static PoisonContainerObjectPool instance;

    public GameObject poisonContainerPrefab;

    public int poisonContainerCount;

    private Queue<GameObject> poisonContaineravailableObjects = new Queue<GameObject>();
    void Start()
    {
        instance = this;
        PoisonContainerFillpool();
    }

    
    void Update()
    {
        
    }

    public void PoisonContainerFillpool()
    {
        for (int i = 0; i < poisonContainerCount; i++)
        {
            var newPoisonBall = Instantiate(poisonContainerPrefab);
            newPoisonBall.transform.SetParent(transform);
            poisonContaineravailableObjects.Enqueue(newPoisonBall);
            newPoisonBall.SetActive(false);
        }
    }

    public void PoisonContainerReturnPool(GameObject gameObject)
    {
        gameObject.SetActive(false);

        poisonContaineravailableObjects.Enqueue(gameObject);
    }

    public GameObject PoisonContainerGetFromPool(Vector3 PoisonBallHitPos)
    {
        var outPoisonContainer = poisonContaineravailableObjects.Dequeue();

        outPoisonContainer.SetActive(true);

        outPoisonContainer.transform.position = PoisonBallHitPos;

        return outPoisonContainer;
    }
}
