using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class OpeningAnimation : MonoBehaviour
{
    [SerializeField] private VideoPlayer openingAnimation;
    public double currentTime;
    public double totalTime;
    public float volume;
    private static readonly string BackgroundPref = "BackgroundPref";
    private float backgroundFloat;
    void Awake()
    {
        openingAnimation = GetComponent<VideoPlayer>();
        openingAnimation.loopPointReached += TransToFirstLevel;
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
    }
    
    void Update()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        openingAnimation.SetDirectAudioVolume(0, backgroundFloat);

        if(GameManager.Instance.StopPanel == true)
        {
            openingAnimation.Pause();
        }
        else
        {
            openingAnimation.Play();
        }
    }

    void TransToFirstLevel(UnityEngine.Video.VideoPlayer vp)
    {
        SceneController.Instance.TransitionToFirstLevel();
    }
}
