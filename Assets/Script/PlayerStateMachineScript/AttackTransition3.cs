using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTransition3 : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerController.instance.isAttacking = false;
    }
}
