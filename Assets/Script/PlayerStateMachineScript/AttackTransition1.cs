using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTransition1 : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (PlayerController.instance.isAttacking)
        {
            PlayerController.instance.anim.Play("attack2");
        }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerController.instance.isAttacking = false;
    }
}
