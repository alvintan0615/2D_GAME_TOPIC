using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetting : MonoBehaviour
{
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundsEffectPref = "SoundEffecfPref";
    private float backgroundFloat, soundEffectFloat;
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectAudio;

    void Awake()
    {
        ContinueSettings();
    }

    void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        soundEffectFloat = PlayerPrefs.GetFloat(SoundsEffectPref);

        backgroundAudio.volume = backgroundFloat;

        for (int i = 0; i < soundEffectAudio.Length; i++)
        {
            soundEffectAudio[i].volume = soundEffectFloat;
        }
    }
}
