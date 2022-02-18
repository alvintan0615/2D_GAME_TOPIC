using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineTieRodFloor : MonoBehaviour
{
    public Animator animator;
    public Animator animatorTR;
    public bool DoAction = true;
    public bool OneRound = false;
    public bool OneRoundTR = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.A))
        {
            if (MachineController.BySelf == true)
            {
                return;
            }

            if (MachineController.IsFloor == true && MachineController.DoAction == true)
            {
                return;
            }

            if(MachineController.UpToDown == false && MachineController.DoAction == false)
            {
                return;
            }

            if(MachineController.IsFloor == false && DoAction == true)
            {
                Debug.Log("aaa");
                animator.SetTrigger("DefaultToDown");
                animatorTR.SetTrigger("IsDefault");
                StartCoroutine(DelayOneRound());
                DoAction = false;
                MachineController.IsFloor = true;
                if(OneRound == true && MachineController.UpToDown == true)
                {
                    animator.SetTrigger("UpToDown");
                }

                if(OneRoundTR == true && MachineTieRodController.PullUp == true)
                {
                    animatorTR.SetTrigger("PullDown");
                }

                if (OneRoundTR == true && MachineTieRodController.PullUp == false)
                {
                    animatorTR.SetTrigger("PullUp");
                }

            }

            else
            {
                return;
            }
        }
    }


    public IEnumerator DelayOneRound()
    {
        yield return new WaitForSeconds(3);
        MachineController.UpToDown = false;
        MachineController.OneRound = false;
        MachineController.IsDefault = false;
        DoAction = true;
        OneRound = true;
        OneRoundTR = true;
    }
}
