using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackTransition2 : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerStatus.isAttackingTransition = true;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Human_Skill.isAttack = false;
        PlayerStatus.isAttackingTransition = false;
    }
}
