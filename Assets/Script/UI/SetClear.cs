using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetClear : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.playerStats.attackData.minDamage = 4;
        GameManager.Instance.playerStats.attackData.maxDamage = 6;
    }

    void Update()
    {
        
    }
}
