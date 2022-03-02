using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomTree_Attack : StateMachineBehaviour
{
    [SerializeField] MushRoomTreeController MushRoomTreeCtrl;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MushRoomTreeCtrl = animator.GetComponent<MushRoomTreeController>();
        MushRoomTreeCtrl.isAttack = true;
        //NewPlayerController.instance.fireSkillEffectPoint();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MushRoomTreeCtrl.isAttack = false;
    }
}
