using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineController : MonoBehaviour
{
    public Animator animator;
    static public bool IsDefault = true;
    static public bool UpToDown = true;
    static public bool OneRound = false;
    static public bool DoAction = false;


    static public bool IsFloor = false;
    static public bool BySelf = false;

    public AudioSource Machine;
    public void Start()
    {
        DoAction = true;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.A))
        {
            if (IsDefault == true && (UpToDown == true || IsFloor == false) && OneRound == false && DoAction == true)
            {
                IsDefault = false;
                animator.SetTrigger("DefaultToDown");
                MahcineSound();
                StartCoroutine(DelayDefaultToDown());
                DoAction = false;
                IsFloor = true;
            }

            if (IsDefault == false && (UpToDown == false || IsFloor == true ) && DoAction == true && OneRound == false)
            {
                animator.SetTrigger("DownToUp");
                MahcineSound();
                StartCoroutine(DelayOneRound());
                DoAction = false;
                IsFloor = false;
                BySelf = false;
            }

            if (IsDefault == false && OneRound == true && (UpToDown == true || IsFloor == false) && DoAction == true )
            {
                animator.SetTrigger("UpToDown");
                MahcineSound();
                StartCoroutine(DelayDownToUp());
                DoAction = false;
                IsFloor = false;
                BySelf = true;
            }

            else
            {
                DoAction = false;
            }
        }
    }


    public IEnumerator DelayDefaultToDown()
    {
        yield return new WaitForSeconds(3);
        UpToDown = false;
        DoAction = true;
    }

    public IEnumerator DelayOneRound()
    {
        yield return new WaitForSeconds(3);
        UpToDown = true;
        OneRound = true;
        DoAction = true;
    }

    public IEnumerator DelayDownToUp()
    {
        yield return new WaitForSeconds(3);
        UpToDown = false;
        OneRound = false;
        DoAction = true;
    }

    public void MahcineSound()
    {
        Machine.Play();
    }
}
