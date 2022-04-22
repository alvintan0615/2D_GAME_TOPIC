using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterOnSound : MonoBehaviour
{
    public AudioSetting audioSetting;
    //public AudioSource TeleporterSound;
    //public bool canPlaySound = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSetting = GameObject.Find("SFX").GetComponent<AudioSetting>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //canPlaySound = true;
            //TeleporterSound.mute = false;
            audioSetting.soundEffectAudio[33].mute = false;
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        canPlaySound = true;
    //        TeleporterSound.mute = false;
    //    }
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //canPlaySound = false;
            //TeleporterSound.mute = true;
            audioSetting.soundEffectAudio[33].mute = true;
        }
    }
}
