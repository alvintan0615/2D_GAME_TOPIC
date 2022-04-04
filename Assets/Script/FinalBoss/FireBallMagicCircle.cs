using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMagicCircle : MonoBehaviour
{
    public GameObject dust;
    
    private int fireBallNum;
    private float x;
    public int fireBallTime;
    void OnEnable()
    {
        
    }
    void Update()
    {

    }

    /*public void CreateFireBallBase()
    {
        if(fireBallTime > 0)
        {
            fireBallNum = Random.Range(1, 3);

            for (int i = 0; i < fireBallNum; i++)
            {
                x = Random.Range(-76f, -40f);
                Instantiate(fireBallBase, new Vector3(x, -10f, 0), Quaternion.identity);
            }
        }
    }*/
}
