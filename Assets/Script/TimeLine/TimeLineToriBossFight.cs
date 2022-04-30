using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Linq;
public class TimeLineToriBossFight : MonoBehaviour
{
    public PlayableDirector mDirector;
    public float normalizedTime;
    public GameObject bossArea;
    void Start()
    {
        bossArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var timelineAsset = mDirector.playableAsset as TimelineAsset;
        var track = timelineAsset.GetOutputTracks().FirstOrDefault(t => t.name == "Player");
        var track1 = timelineAsset.GetOutputTracks().FirstOrDefault(t => t.name == "Human");
        normalizedTime = (float)(mDirector.time / mDirector.duration);
        if(GameManager.Instance.playerStats!= null)
        {
            mDirector.SetGenericBinding(track1, GameManager.Instance.playerStats.transform.GetChild(0).gameObject);
            mDirector.SetGenericBinding(track, GameManager.Instance.playerStats.gameObject);
        }
        if(EventManager.Instance.fireVillege_Dad == true)
        {
            PlayerStatus.isDialouging = true;
            mDirector.Play();
        }

        if(normalizedTime >=0.01f && normalizedTime < 0.99f)
        {
            GameManager.Instance.notDead = true;
        }

        if (normalizedTime >= 0.99f && EventManager.Instance.fireVillege_TimelineBeforeToriBoss == false)
        {
            //PlayerStatus.isDialouging = false;
            EventManager.Instance.fireVillege_TimelineBeforeToriBoss = true;
            EventManager.Instance.fireVillege_BossStoryLine = true;
            this.gameObject.SetActive(false);
        }


    }
}
