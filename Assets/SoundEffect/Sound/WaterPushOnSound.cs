using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPushOnSound : MonoBehaviour
{
    //public AudioSource WaterSound;
    public AudioSetting audioSetting;
    public bool canPlaySound = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSetting = GameObject.Find("SFX").GetComponent<AudioSetting>();
        canPlaySound = false;
        //WaterSound.mute = true;
        audioSetting.soundEffectAudio[19].mute = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canPlaySound == true)
        {
            //WaterSound.mute = false;
            audioSetting.soundEffectAudio[19].mute = false;
        }
        else
        {
            //WaterSound.mute = true;
            audioSetting.soundEffectAudio[19].mute = true;
        }

    }

    public void WaterPushSound()
    {
        //WaterSound.Play();
        audioSetting.soundEffectAudio[19].Play();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canPlaySound = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canPlaySound = false;
        }
    }
}
