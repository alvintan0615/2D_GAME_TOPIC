﻿using System.Collections;
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
    private void Awake()
    {
        excuse = GetComponent<VideoPlayer>();
        totalTime = excuse.clip.length;
    }

    private void OnEnable()
    {
        //Mute BackGroundMusic
    }

    private void OnDisable()
    {
        //Play BackGroundMusic
    }

    void Update()
    {
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
