using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tori_Sewer_DizzyToGround : StateMachineBehaviour
{
    [SerializeField] Boss_Tori tori;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tori = GameObject.FindGameObjectWithTag("Tori").GetComponent<Boss_Tori>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tori.Dizzy();
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
