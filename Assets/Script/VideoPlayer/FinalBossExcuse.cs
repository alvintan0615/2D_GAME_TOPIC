using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class FinalBossExcuse : MonoBehaviour
{
    [SerializeField]private VideoPlayer excuse;
    //public GameObject fixVideoPanel;
    public double currentTime;
    public double totalTime;
    [SerializeField] private float timer;
    private bool isSkipOK = false;
    public SceneFader sceneFaderPrefab;

    public AudioSetting audioSetting;
    private static readonly string BackgroundPref = "BackgroundPref";
    private float backgroundFloat;
    private void Awake()
    {
        excuse = GetComponent<VideoPlayer>();
        totalTime = excuse.clip.length;
        audioSetting = GameObject.Find("SFX").GetComponent<AudioSetting>();
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
    }

    private void OnEnable()
    {
        //Mute BackGroundMusic
        audioSetting.backgroundAudio[0].Pause();
    }

    private void OnDisable()
    {
        //Play BackGroundMusic
        audioSetting.backgroundAudio[0].UnPause();
    }

    void Update()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        excuse.SetDirectAudioVolume(0, backgroundFloat);

        if (GameManager.Instance.StopPanel == true)
        {
            excuse.Pause();
        }
        else
        {
            excuse.Play();
        }

        currentTime = excuse.time;

        if (currentTime >= totalTime)
        {
            EventManager.Instance.finalbossExcuseVideo = true;
            excuse.Pause();
            this.gameObject.SetActive(false);
        }
        skipAnimation();

    }

    void skipAnimation()
    {
        if (Input.GetKey(KeyCode.Space) && isSkipOK == false)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                isSkipOK = true;
                EventManager.Instance.finalbossExcuseVideo = true;
                excuse.Pause();
                this.gameObject.SetActive(false);
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && timer < 1f)
        {
            timer = 0f;
        }
    }

}
