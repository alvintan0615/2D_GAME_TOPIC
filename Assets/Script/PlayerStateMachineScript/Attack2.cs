using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2 : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerController.instance.isAttack = true;

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerController.instance.isAttack = false;
    }
}
