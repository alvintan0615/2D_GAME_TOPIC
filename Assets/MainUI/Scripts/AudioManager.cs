using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundsEffectPref = "SoundEffecfPref";
    private int firstPlayInt;
    public Slider backgroundSlider, soundEffectSlider;
    private float backgroundFloat, soundEffectFloat;
    public AudioSource[] backgroundAudio;
    public AudioSource[] soundEffectAudio;

    public bool isBoss = false;
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.pause = false;

        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0) //default soundSetting
        {
            backgroundFloat = 0.125f;
            soundEffectFloat = 0.75f;
            backgroundSlider.value = backgroundFloat;
            soundEffectSlider.value  = soundEffectFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SoundsEffectPref, soundEffectFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            soundEffectFloat = PlayerPrefs.GetFloat(SoundsEffectPref);
            backgroundSlider.value = backgroundFloat;
            soundEffectSlider.value = soundEffectFloat;
        }

        isBoss = false;

        backgroundAudio[0].mute = false;
        backgroundAudio[0].Play();
        backgroundAudio[1].mute = true;
    }

    public void SaveSoundSesttings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundsEffectPref, soundEffectSlider.value);
    }

    void OnApplicationFocus(bool InFocus)
    {
        if(!InFocus)
        {
            SaveSoundSesttings();
        }
    }

    public void UpdateSound()
    {
        //backgroundAudio.volume = backgroundSlider.value;
        for (int i = 0; i < backgroundAudio.Length; i++)
        {
            backgroundAudio[i].volume = backgroundSlider.value;
        }


        for (int i = 0;i<soundEffectAudio.Length; i++)
        {
            soundEffectAudio[i].volume = soundEffectSlider.value;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        Debug.Log("BackgroundPref" + PlayerPrefs.GetFloat(BackgroundPref));
        Debug.Log("SoundsEffectPref" + PlayerPrefs.GetFloat(SoundsEffectPref));
    }
}
