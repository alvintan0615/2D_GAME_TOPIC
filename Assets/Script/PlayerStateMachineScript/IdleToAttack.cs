using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleToAttack : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerStatus.isHurting = false;
        Human_Skill.isHurt = false;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerStatus.isSkilling = false;
        Human_Skill.isCirleSkill = false;
        Human_Skill.isGroundSkill = false;
        PlayerStatus.isHurting = false;
        Human_Skill.isHurt = false;
        //PlayerStatus.isDashing = false;
        if (Human_Skill.isAttack == true)
        {
            //NewPlayerController.instance.currentHumanState = "Human_NormalAttack1";
            Human_Skill.animator.Play("Human_NormalAttack1");
        }

        PlayerStatus.isAttacking = false;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Human_Skill.isAttack = false;
    }
}
