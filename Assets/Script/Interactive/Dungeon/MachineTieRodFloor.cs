using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineTieRodFloor : MonoBehaviour
{
    public Animator animator;
    public Animator animatorTR;
    public bool DoAction = true;
    public bool OneRound = false;
    
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
            if(MachineController.IsFloor == false && DoAction == true)
            {
                animator.SetTrigger("UpToDown");
                animatorTR.SetTrigger("IsDefault");
                StartCoroutine(DelayOneRound());
                DoAction = false;
                MachineController.IsFloor = true;
                if(OneRound == true && MachineTieRodController.PullUp == true)
                {
                    animatorTR.SetTrigger("PullDown");
                }

                if (OneRound == true && MachineTieRodController.PullUp == false)
                {
                    animatorTR.SetTrigger("PullUp");
                }
            }

            if (MachineController.IsFloor == true && DoAction == true)
            {
                return;
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
        MachineController.OneRound = true;
        DoAction = true;
        OneRound = true;
    }
}
