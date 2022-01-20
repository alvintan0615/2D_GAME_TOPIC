using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackTransition1 : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerStatus.isAttackingTransition = true;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NewPlayerController.instance.animator[0].SetFloat("Run", 0);
        if (Human_Skill.isAttack == true && PlayerStatus.isAttacking == true)
        {
            //NewPlayerController.instance.currentHumanState = "Human_NormalAttack2";
            Human_Skill.animator.Play("Human_NormalAttack2");
            PlayerStatus.isAttacking = false;
        }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Human_Skill.isAttack = false;
        PlayerStatus.isAttackingTransition = false;
    }
}
