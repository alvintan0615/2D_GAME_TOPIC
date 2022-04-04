using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss_FirstPart_FireBallFire : StateMachineBehaviour
{
    [SerializeField] FinalBoss_FirstPart FinalBoss_FirstPart;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FinalBoss_FirstPart = GameObject.FindGameObjectWithTag("FinalBoss_FirstPart").GetComponent<FinalBoss_FirstPart>();
        FinalBoss_FirstPart.FireDustOn();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FinalBoss_FirstPart.FireDustOff();
        FinalBoss_FirstPart.FireBallMagicCircleOff();
    }
}
