using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Hurt : StateMachineBehaviour
{
    [SerializeField] CatController catController;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        catController = animator.GetComponent<CatController>();
        catController.isHurt = true;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        catController.isHurt = false;
    }
}
