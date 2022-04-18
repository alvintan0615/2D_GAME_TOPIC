using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon_AllScreenSkill : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerStatus.isHurting = true;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerStatus.isHurting = false;
    }
}
