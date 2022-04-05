using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss_FirstPart_MagicBallLerpMove : StateMachineBehaviour
{
    [SerializeField] FinalBoss_FirstPart FinalBoss_FirstPart;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FinalBoss_FirstPart = GameObject.FindGameObjectWithTag("FinalBoss_FirstPart").GetComponent<FinalBoss_FirstPart>();
        FinalBoss_FirstPart.instance.isMagicBallMove = true;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FinalBoss_FirstPart.LerpMagicBallMove();
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FinalBoss_FirstPart.LerpMagicBallMoveColor();
        FinalBoss_FirstPart.instance.isMagicBallMove = false;
    }
}
