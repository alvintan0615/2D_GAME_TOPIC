using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_PoisonBallFire : MonoBehaviour
{
    [SerializeField] private GameObject posionPos;
    [SerializeField] private CatController catController;
    [SerializeField] private float fireDir;
    void Start()
    {
        posionPos = transform.GetChild(0).gameObject;
        catController = GetComponent<CatController>();
    }

    void Update()
    {
        if (catController.isFaceRight == true)
        {
            fireDir = 1f;
        }
            

        if (catController.isFaceRight == false)
        {
            fireDir = -1f;
        }
            

    }

    void PosionAttack()
    {
        PoisonBallObjcetPool.instance.PoisonBallGetFromPool2(posionPos.transform.position,fireDir);
    }
}
