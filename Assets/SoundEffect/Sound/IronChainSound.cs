using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronChainSound : MonoBehaviour
{
    //public AudioSource ironChain;

    public AudioSetting audioSetting;
    // public bool canPlaySound = false;
    // Start is called before the first frame update
    void Start()
    {
        //canPlaySound = false;
        //ironChain.mute = true;
        audioSetting = GameObject.Find("SFX").GetComponent<AudioSetting>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(canPlaySound == true)
        //{
        //    ironChain.mute = false;
        //}
        //else
        //{
        //    ironChain.mute = true;
        //}
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if(collision.tag == "Player")
    //    {
    //        canPlaySound = true; 
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if(collision.tag == "Player")
    //    {
    //        canPlaySound = false;
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //ironChain.Play();
            audioSetting.soundEffectAudio[31].Play();
        }
    }
}
