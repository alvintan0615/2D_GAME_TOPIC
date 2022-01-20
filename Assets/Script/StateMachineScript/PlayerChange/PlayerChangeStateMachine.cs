﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeStateMachine : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerStatus.isChanging = true;
        //NewPlayerController.instance.fireSkillEffectPoint();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerStatus.isChanging = true;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerStatus.isChanging = false;

    }
}
