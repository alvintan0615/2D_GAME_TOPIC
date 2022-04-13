using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBallObjcetPool : MonoBehaviour
{
    public static PoisonBallObjcetPool instance;

    public GameObject poisonBallPrefab;

    public int poisonBallCount;

    private Queue<GameObject> poisonBallavailableObjects = new Queue<GameObject>();
    void Start()
    {
        instance = this;
        PoisonBallFillpool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PoisonBallFillpool()
    {
        for (int i = 0; i < poisonBallCount; i++)
        {
            var newPoisonBall = Instantiate(poisonBallPrefab);
            newPoisonBall.transform.SetParent(transform);
            poisonBallavailableObjects.Enqueue(newPoisonBall);
            newPoisonBall.SetActive(false);
        }
    }

    public void PoisonBallReturnPool(GameObject gameObject)
    {
        gameObject.SetActive(false);

        poisonBallavailableObjects.Enqueue(gameObject);
    }

    public GameObject PoisonBallGetFromPool()
    {
        var outPoisonBall = poisonBallavailableObjects.Dequeue();

        outPoisonBall.SetActive(true);

        return outPoisonBall;
    }
}
