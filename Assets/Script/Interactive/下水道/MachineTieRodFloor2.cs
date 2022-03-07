using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineTieRodFloor2 : MonoBehaviour
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
            if (MachineController2.BySelf == true)
            {
                return;
            }

            if (MachineController2.IsFloor == true && MachineController2.DoAction == true)
            {
                return;
            }

            if (MachineController2.UpToDown == false && MachineController2.DoAction == false)
            {
                return;
            }

            if (MachineController2.IsFloor == false && DoAction == true)
            {
                Debug.Log("aaa");
                animator.SetTrigger("DefaultToDown2");
                animatorTR.SetTrigger("IsDefault2");
                StartCoroutine(DelayOneRound());
                DoAction = false;
                MachineController2.IsFloor = true;
                if (OneRound == true && MachineController2.UpToDown == true)
                {
                    animator.SetTrigger("UpToDown2");
                }

                if (OneRoundTR == true && MachineTieRodController2.PullUp == true)
                {
                    animatorTR.SetTrigger("PullDown2");
                }

                if (OneRoundTR == true && MachineTieRodController2.PullUp == false)
                {
                    animatorTR.SetTrigger("PullUp2");
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
        MachineController2.UpToDown = false;
        MachineController2.OneRound = false;
        MachineController2.IsDefault = false;
        DoAction = true;
        OneRound = true;
        OneRoundTR = true;
    }
}
