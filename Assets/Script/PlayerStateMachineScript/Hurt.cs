using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerStatus.isHurting = true;
        
        //CineMachineShake.instance.ShakeCamera(5f, 0.1f);
        //NewPlayerController.instance.fireSkillEffectPoint();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerStatus.isHurting = true;

    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerStatus.isHurting = false;
        Human_Skill.isHurt = false;

    }
}
