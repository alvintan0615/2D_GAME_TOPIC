using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryGameObject : MonoBehaviour
{
    public float destoryTimer;
    void Start()
    {
        
    }

    void Update()
    {
        Destroy(this.gameObject,destoryTimer);
    }
}
