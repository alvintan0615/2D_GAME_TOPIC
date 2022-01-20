using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon_NormalAttackTrans2 : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        PlayerStatus.isAttackingTransition = true;
        //NewPlayerController.instance.fireSkillEffectPoint();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NewPlayerController.instance.animator[1].SetFloat("Run", 0);
        if (Demon_Skill.instance.isNormalAttack == true && PlayerStatus.isAttacking == true)
        {
            //NewPlayerController.instance.currentHumanState = "Human_NormalAttack2";
            NewPlayerController.instance.DemonState("Demon_NormalAttack3");
            PlayerStatus.isAttacking = false;
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerStatus.isAttacking = false;
        Demon_Skill.instance.isNormalAttack = false;
    }
}
