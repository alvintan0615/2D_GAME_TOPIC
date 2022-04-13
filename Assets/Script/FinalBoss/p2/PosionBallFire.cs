using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosionBallFire : MonoBehaviour
{
    [SerializeField] private GameObject posionPos;
    void Start()
    {
        posionPos = transform.GetChild(1).gameObject;
    }

    void PosionAttack()
    {
        PoisonBallObjcetPool.instance.PoisonBallGetFromPool(posionPos.transform.position);
    }
}
