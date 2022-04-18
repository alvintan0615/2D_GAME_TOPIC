using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_PoisonAttack : StateMachineBehaviour
{
    [SerializeField] CatController catController;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        catController = animator.GetComponent<CatController>();
        catController.isAttack = true;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        catController.isAttack = false;
    }
}
