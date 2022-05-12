using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class EndingAnimation : MonoBehaviour
{
    [SerializeField] private VideoPlayer endingAnimation;
    public double currentTime;
    public double totalTime;
    public float volume;
    private static readonly string BackgroundPref = "BackgroundPref";
    private float backgroundFloat;
    [SerializeField] private float timer;
    private bool isTrans = false;
    public GameObject toMainScene;
    void Awake()
    {
        endingAnimation = GetComponent<VideoPlayer>();
        totalTime = endingAnimation.clip.length;
        toMainScene.SetActive(false);
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        PlayerStatus.isDialouging = false;
    }

    void Update()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        endingAnimation.SetDirectAudioVolume(0, backgroundFloat);
        currentTime = endingAnimation.time;
        if (GameManager.Instance.StopPanel == true)
        {
            endingAnimation.Pause();
        }
        else
        {
            endingAnimation.Play();
        }

        if (currentTime >= totalTime)
        {
            endingAnimation.Pause();
            toMainScene.SetActive(true);
        }
        

        if (isTrans == true)
        {
            endingAnimation.Pause();
            toMainScene.SetActive(true);
        }
        skipAnimation();
    }

    void skipAnimation()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
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
