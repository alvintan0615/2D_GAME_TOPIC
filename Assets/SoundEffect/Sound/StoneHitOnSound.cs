using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneHitOnSound : MonoBehaviour
{
    //public AudioSource StoneHit;
    public AudioSetting audioSetting;
    public bool canPlaySound = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSetting = GameObject.Find("SFX").GetComponent<AudioSetting>();
        canPlaySound = false;
        //StoneHit.mute = true;
        audioSetting.soundEffectAudio[32].mute = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canPlaySound == true)
        {
            //StoneHit.mute = false;
            audioSetting.soundEffectAudio[32].mute = false;
        }
        else
        {
            //StoneHit.mute = true;
            audioSetting.soundEffectAudio[32].mute = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canPlaySound = true;
            //StoneHit.mute = false;
            audioSetting.soundEffectAudio[32].mute = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canPlaySound = false;
            //StoneHit.mute = true;
            audioSetting.soundEffectAudio[32].mute = true;
        }
    }

    public void StoneHitSound()
    {
        audioSetting.soundEffectAudio[32].Play();
    }
}
