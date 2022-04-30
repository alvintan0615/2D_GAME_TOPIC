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
    [SerializeField]private float timer;
    private bool isTrans = false;
    private bool isSkipOK = false;
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
        
        if (GameManager.Instance.StopPanel == true)
        {
            openingAnimation.Pause();
        }
        else
        {
            openingAnimation.Play();
        }
        skipAnimation();

        if(isTrans == true)
        {
            isTrans = false;
            SceneController.Instance.TransitionToFirstLevel();
        }
    }

    void TransToFirstLevel(UnityEngine.Video.VideoPlayer vp)
    {
        SceneController.Instance.TransitionToFirstLevel();
    }

    void skipAnimation()
    {
        if (Input.GetKey(KeyCode.Space) && isSkipOK == false)
        {
            timer += Time.deltaTime;
            if(timer >= 3f)
            {
                isTrans = true;
                isSkipOK = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && timer < 3f)
        {
            timer = 0f;
        }
    }
}
