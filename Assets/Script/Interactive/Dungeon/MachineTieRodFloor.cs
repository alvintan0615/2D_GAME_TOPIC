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

    //public AudioSource TieRod;
    //public AudioSource Machine;
    public AudioSetting audioSetting;

    // Start is called before the first frame update
    void Start()
    {
        audioSetting = GameObject.Find("SFX").GetComponent<AudioSetting>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.A) && GameManager.Instance.Ken_Human == true)
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
                //FloorTieRodSound();
                //MachineSoundDefault();
                audioSetting.soundEffectAudio[28].Play();
                StartCoroutine(DelayOneRound());
                DoAction = false;
                MachineController.IsFloor = true;
                if(OneRound == true && MachineController.UpToDown == true)
                {
                    animator.SetTrigger("UpToDown");
                    //FloorTieRodSound();
                }

                if(OneRoundTR == true && MachineTieRodController.PullUp == true)
                {
                    animatorTR.SetTrigger("PullDown");
                    //FloorTieRodSound();
                }

                if (OneRoundTR == true && MachineTieRodController.PullUp == false)
                {
                    animatorTR.SetTrigger("PullUp");
                    //FloorTieRodSound();
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

    //public void FloorTieRodSound()
    //{
    //    TieRod.Play();
    //}

    public void MachineSoundDefault()
    {
       // Machine.Play();
    }
}
