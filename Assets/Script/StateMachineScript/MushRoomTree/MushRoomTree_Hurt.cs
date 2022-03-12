using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomTree_Hurt : StateMachineBehaviour
{
    [SerializeField] MushRoomTreeController MushRoomTreeCtrl;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MushRoomTreeCtrl = animator.GetComponent<MushRoomTreeController>();
        MushRoomTreeCtrl.isHurt = true;
        //NewPlayerController.instance.fireSkillEffectPoint();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MushRoomTreeCtrl.rb.velocity = new Vector2(0, MushRoomTreeCtrl.rb.velocity.y);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MushRoomTreeCtrl.isHurt = false;
    }
}
