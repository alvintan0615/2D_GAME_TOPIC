using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    public static AudioSetting instance;

    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundsEffectPref = "SoundEffecfPref";
    private float backgroundFloat, soundEffectFloat;
    public AudioSource[] backgroundAudio;
    public AudioSource[] soundEffectAudio;

    public Slider BGEffectsSlider;
    public Slider SoundEffectsSlider;

    public GameObject Boss;
    void Awake()
    {
        instance = this;

        //ContinueSettings();
        //GetSoundVolume();

        //SoundEffectsSlider.value = PlayerPrefs.GetFloat(SoundsEffectPref);
        //BGEffectsSlider.value = PlayerPrefs.GetFloat(BackgroundPref);
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        soundEffectFloat = PlayerPrefs.GetFloat(SoundsEffectPref);
        BGEffectsSlider.value = backgroundFloat;
        SoundEffectsSlider.value = soundEffectFloat;
        //Debug.Log(PlayerPrefs.GetFloat(SoundsEffectPref));
    }

    public void Start()
    {
        backgroundAudio[0].mute = false;
        backgroundAudio[1].gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Boss.activeInHierarchy == true)
        {
            backgroundAudio[0].mute = true;
            backgroundAudio[1].gameObject.SetActive(true);
        }
        

        if(Input.GetKeyDown(KeyCode.P))
        {
            backgroundAudio[0].mute = false;
            backgroundAudio[1].gameObject.SetActive(false);
        }


        //backgroundAudio.volume = BGEffectsSlider.value;
        for (int i = 0; i < backgroundAudio.Length; i++)
        {
            backgroundAudio[i].volume = BGEffectsSlider.value;
        }

        for (int i = 0; i < soundEffectAudio.Length; i++)
        {
            soundEffectAudio[i].volume = SoundEffectsSlider.value;
        }
    }

    void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        soundEffectFloat = PlayerPrefs.GetFloat(SoundsEffectPref);

        //backgroundAudio.volume = backgroundFloat;
        for (int i = 0; i < backgroundAudio.Length; i++)
        {
            backgroundAudio[i].volume = BGEffectsSlider.value;
        }

        for (int i = 0; i < soundEffectAudio.Length; i++)
        {
            soundEffectAudio[i].volume = soundEffectFloat;
        }
    }
    public void setSoundVolume()
    {
        PlayerPrefs.SetFloat(BackgroundPref, BGEffectsSlider.value);
        PlayerPrefs.SetFloat(SoundsEffectPref, SoundEffectsSlider.value);
    }

    public void GetSoundVolume()
    {
        BGEffectsSlider.value = PlayerPrefs.GetFloat(BackgroundPref);
        SoundEffectsSlider.value = PlayerPrefs.GetFloat(SoundsEffectPref);
    }

    public void ChangeBossBGMusic()
    {
        backgroundAudio[0].mute = true;
        backgroundAudio[1].Play();
        backgroundAudio[1].mute = false;
    }
}
