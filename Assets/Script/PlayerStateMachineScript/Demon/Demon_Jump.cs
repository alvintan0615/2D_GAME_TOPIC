using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon_Jump : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Demon_Skill.instance.isBeamSkill = false;
        Demon_Skill.instance.isAllScreenSkill = false;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Demon_Skill.instance.isNormalAttack == true)
        {
            //NewPlayerController.instance.currentHumanState = "Human_NormalAttack1";
            NewPlayerController.instance.DemonState("Demon_NormalAttack1");
        }

        PlayerStatus.isAttacking = false;
        PlayerStatus.isAttackingTransition = false;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Demon_Skill.instance.isNormalAttack = false;
        
    }
}
