using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundsEffectPref = "SoundEffecfPref";
    private float backgroundFloat, soundEffectFloat;
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectAudio;

    public Slider BGEffectsSlider;
    public Slider SoundEffectsSlider;
    void Awake()
    {
        ContinueSettings();
        BGEffectsSlider.value = PlayerPrefs.GetFloat(BackgroundPref);
        SoundEffectsSlider.value = PlayerPrefs.GetFloat(SoundsEffectPref);
    }

    private void Update()
    {
        Debug.Log(PlayerPrefs.GetFloat(SoundsEffectPref));

        backgroundAudio.volume  = BGEffectsSlider.value ;

        for (int i = 0; i < soundEffectAudio.Length; i++)
        {
            soundEffectAudio[i].volume = SoundEffectsSlider.value;
        }
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
    public void setSoundVolume()
    {
        PlayerPrefs.SetFloat("BackgroundPref", BGEffectsSlider.value);
        PlayerPrefs.SetFloat("SoundEffecfPref", SoundEffectsSlider.value);
    }

}
