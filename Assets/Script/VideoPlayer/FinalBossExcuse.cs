using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class FinalBossExcuse : MonoBehaviour
{
    [SerializeField]private VideoPlayer excuse;
    public GameObject fixVideoPanel;
    public double currentTime;
    public double totalTime;
    private void Awake()
    {
        excuse = GetComponent<VideoPlayer>();
        totalTime = excuse.clip.length;
    }

    private void OnEnable()
    {
        fixVideoPanel.SetActive(true);
    }

    private void OnDisable()
    {
        fixVideoPanel.SetActive(false);
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= totalTime)
        {
            EventManager.Instance.finalbossExcuseVideo = true;
            this.gameObject.SetActive(false);
        }
    }
}
