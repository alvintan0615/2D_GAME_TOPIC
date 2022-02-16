using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineController : MonoBehaviour
{
    public Animator animator;
    public bool IsDefault = true;
    static public bool UpToDown = false;
    static public bool OneRound = false;
    public bool DoAction = false;


    static public bool IsFloor = true;
    public void Start()
    {
        DoAction = true;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.A))
        {
            if (IsDefault == true && UpToDown == false && OneRound == false && DoAction == true)
            {
                IsDefault = false;
                animator.SetTrigger("DefaultToUp");
                StartCoroutine(DelayDefaultToUp());
                DoAction = false;
                IsFloor = false;
            }

            if(IsDefault == false && (UpToDown == true || IsFloor == false) && DoAction == true && OneRound == false)
            { 
                animator.SetTrigger("UpToDown");
                StartCoroutine(DelayOneRound());
                DoAction = false;
                IsFloor = true;
            }

            if(OneRound == true && UpToDown == false && DoAction == true && IsFloor == true && IsDefault == false)
            {
                animator.SetTrigger("DownToUp");
                StartCoroutine(DelayDownToUp());
                DoAction = false;
                IsFloor = false;
            }

            else
            {
                DoAction = false;
            }
        }
    }


    public IEnumerator DelayDefaultToUp()
    {
        yield return new WaitForSeconds(3);
        UpToDown = true;
        DoAction = true;
        
    }

    public IEnumerator DelayOneRound()
    {
        yield return new WaitForSeconds(3);
        UpToDown = false;
        OneRound = true;
        DoAction = true;
        
    }

    public IEnumerator DelayDownToUp()
    {
        yield return new WaitForSeconds(3);
        UpToDown = true;
        OneRound = false;
        DoAction = true;
        
    }
}
