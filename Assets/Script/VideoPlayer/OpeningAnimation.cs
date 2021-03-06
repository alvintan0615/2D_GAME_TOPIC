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
    public GameObject toFirstLevel;
    void Awake()
    {
        openingAnimation = GetComponent<VideoPlayer>();
        totalTime = openingAnimation.clip.length;
        toFirstLevel.SetActive(false);
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
    }
    
    void Update()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        openingAnimation.SetDirectAudioVolume(0, backgroundFloat);
        currentTime = openingAnimation.time;
        if (GameManager.Instance.StopPanel == true)
        {
            openingAnimation.Pause();
        }
        else
        {
            openingAnimation.Play();
        }

        if (currentTime >= totalTime)
        {
            openingAnimation.Pause();
            toFirstLevel.SetActive(true);
        }

        if (isTrans == true)
        {
            openingAnimation.Pause();
            toFirstLevel.SetActive(true);
        }
        skipAnimation();
    }

    void skipAnimation()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            timer += Time.deltaTime;
            if(timer >= 1f)
            {
                isTrans = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && timer < 1f)
        {
            timer = 0f;
        }
    }
}
