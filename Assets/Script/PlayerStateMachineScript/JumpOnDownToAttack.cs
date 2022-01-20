using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnDownToAttack : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerStatus.isDashing = false;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerStatus.isAttacking = false;


    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Human_Skill.isAttack = false;
    }
}
