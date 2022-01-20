using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTransition : MonoBehaviour
{
    void Attack1()
    {
        
        if (PlayerController.instance.isAttacking == true)
        {
            PlayerController.instance.isAttacking = false;
        }
    }

    void Attack2()
    {
        if (PlayerController.instance.isAttacking == true)
        {
            PlayerController.instance.isAttacking = false;
        }
    }

    void Attack3()
    {
        if (PlayerController.instance.isAttacking == true)
        {
            PlayerController.instance.isAttacking = false;
        }
    }


}
