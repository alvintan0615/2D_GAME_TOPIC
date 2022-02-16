using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineTieRodController : MonoBehaviour
{
    public Animator animator;
    public bool IsDefault = true;
    static public bool PullUp = false;
    public bool DoAction = false;
    public bool OneRound = false;

    

    // Start is called before the first frame update
    void Start()
    {
        DoAction = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.A))
        {
            if(IsDefault == true && DoAction == true)
            {
                animator.SetTrigger("IsDefault");
                StartCoroutine(DelayDoAction());
                DoAction = false;
                IsDefault = false;
                Debug.Log("1111");
            }

            if(IsDefault == false && PullUp == true && DoAction == true && OneRound == false)
            {
                animator.SetTrigger("PullDown");
                StartCoroutine(DelayPullDown());
                DoAction = false;
            }

            if(PullUp == false && OneRound == true && DoAction == true)
            {
                animator.SetTrigger("PullUp");
                StartCoroutine(DelayPullUp());
                DoAction = false;
            }

            else
            {
                DoAction = false;
            }
        }
    }


    public IEnumerator DelayDoAction()
    {
        yield return new WaitForSeconds(3);
        DoAction = true;
        PullUp = true;
    }

    public IEnumerator DelayPullDown()
    {
        yield return new WaitForSeconds(3);
        DoAction = true;
        PullUp = false;
        OneRound = true;
    }

    public IEnumerator DelayPullUp()
    {
        yield return new WaitForSeconds(3);
        DoAction = true;
        PullUp = true;
        OneRound = false;
    }
}
