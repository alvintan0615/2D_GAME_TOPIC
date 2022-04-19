using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatOnSound : MonoBehaviour
{
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

    public void CatAtkSound()
    {
        audioSetting.soundEffectAudio[21].Play();
    }

    public void CatHurtSound()
    {
        audioSetting.soundEffectAudio[23].Play();
    }

    public void CatDeadSound()
    {
        audioSetting.soundEffectAudio[24].Play();
    }
}
