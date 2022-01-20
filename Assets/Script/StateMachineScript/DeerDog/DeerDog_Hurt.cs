using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerDog_Hurt : StateMachineBehaviour
{
    [SerializeField] DeerDogController deerDogCtrl;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         deerDogCtrl = animator.GetComponent<DeerDogController>();
        //NewPlayerController.instance.fireSkillEffectPoint();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        deerDogCtrl.isHurt = true;
        deerDogCtrl.rb.velocity = new Vector2(0, 0);
        /*if(deerDogCtrl.attackTarget != null)
        {
            if(animator.transform.position.x > deerDogCtrl.attackTarget.transform.position.x)
            {
                deerDogCtrl.rb.velocity = new Vector2(10 * Time.deltaTime * 6, 0 * Time.deltaTime);
            }else
                deerDogCtrl.rb.velocity = new Vector2(-10 * Time.deltaTime * 6, 0 * Time.deltaTime);
        }*/
        //deerDogCtrl.rb.velocity = new Vector2(-100 * Time.deltaTime * 5,50 * Time.deltaTime);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        deerDogCtrl.isHurt = false;
    }
}
