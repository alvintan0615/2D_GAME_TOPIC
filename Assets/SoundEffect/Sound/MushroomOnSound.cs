using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomOnSound : MonoBehaviour
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

    public void MushroomTreeCloseAtkSound()
    {
        audioSetting.soundEffectAudio[14].Play();
    }

    public void MushroomTreeFarAtkSound()
    {
        audioSetting.soundEffectAudio[15].Play();
    }

    public void MushroomTreeHurtSound()
    {
        audioSetting.soundEffectAudio[16].Play();
    }

    public void MushroomTreeDeadSound()
    {
        audioSetting.soundEffectAudio[17].Play();
    }
}
