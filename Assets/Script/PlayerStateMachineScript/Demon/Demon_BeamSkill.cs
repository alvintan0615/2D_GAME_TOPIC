using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon_BeamSkill : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerStatus.isSkilling = true;
        //NewPlayerController.instance.fireSkillEffectPoint();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerStatus.isSkilling = true;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerStatus.isSkilling = false;
        Demon_Skill.instance.isBeamSkill = false;
    }
}
