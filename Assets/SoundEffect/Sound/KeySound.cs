using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySound : MonoBehaviour
{
    public AudioSetting audioSetting;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSetting = GameObject.Find("SFX").GetComponent<AudioSetting>();
        audioSetting.soundEffectAudio[36].mute = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && BossKeyGetSound.KeyHasGet == false)
        {
            audioSetting.soundEffectAudio[36].mute = false;
        }

        if (collision.tag == "Player" && BossKeyGetSound.KeyHasGet == true)
        {
            audioSetting.soundEffectAudio[36].mute = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && BossKeyGetSound.KeyHasGet == false)
        {
            audioSetting.soundEffectAudio[36].mute = true;
        }

        if (collision.tag == "Player" && BossKeyGetSound.KeyHasGet == true)
        {
            audioSetting.soundEffectAudio[36].mute = true;
        }
    }

    public void KeySoundUnmuteForTimeLine()
    {
        audioSetting.soundEffectAudio[37].Play();
        audioSetting.soundEffectAudio[37].mute = false;
    }

    public void KeySoundMuteForTimeLine()
    {
        audioSetting.soundEffectAudio[37].mute = true;
    }

}
