using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss_FirstPart_MagicBallFire : StateMachineBehaviour
{
    [SerializeField] FinalBoss_FirstPart FinalBoss_FirstPart;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FinalBoss_FirstPart = GameObject.FindGameObjectWithTag("FinalBoss_FirstPart").GetComponent<FinalBoss_FirstPart>();
        FinalBoss_FirstPart.instance.isMagicBallAttack = true;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FinalBoss_FirstPart.FlipTowardsPlayer();
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FinalBoss_FirstPart.instance.isMagicBallAttack = false;
    }
}
