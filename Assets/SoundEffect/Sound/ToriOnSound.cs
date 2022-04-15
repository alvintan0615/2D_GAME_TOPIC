using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToriOnSound : MonoBehaviour
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

    public void ToriSprayFireSound()
    {
        audioSetting.soundEffectAudio[15].Play();
    }

    public void ToriDizzySound()
    {
        audioSetting.soundEffectAudio[16].Play();
    }

    public void ToriTornaodoSound()
    {
        audioSetting.soundEffectAudio[17].Play();
    }

    public void ToriGroundSprayFireSound()
    {
        audioSetting.soundEffectAudio[18].Play();
    }
}
