using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerDog_Attack : StateMachineBehaviour
{
    [SerializeField] DeerDogController deerDogCtrl;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        deerDogCtrl = animator.GetComponent<DeerDogController>();
        //NewPlayerController.instance.fireSkillEffectPoint();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        deerDogCtrl.isAttack = true;
        deerDogCtrl.rb.velocity = new Vector2(0, 0);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        deerDogCtrl.isAttack = false;
    }
}
