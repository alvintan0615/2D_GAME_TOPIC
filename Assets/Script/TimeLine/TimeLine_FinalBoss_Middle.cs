using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Linq;

public class TimeLine_FinalBoss_Middle : MonoBehaviour
{
    public PlayableDirector mDirector;
    public float normalizedTime;    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        normalizedTime = (float)(mDirector.time / mDirector.duration);

        var timelineAsset = mDirector.playableAsset as TimelineAsset;
        var track1 = timelineAsset.GetOutputTracks().FirstOrDefault(t => t.name == "Player1");

        if (GameManager.Instance.playerStats != null)
        {
            mDirector.SetGenericBinding(track1, GameManager.Instance.playerStats.gameObject);
        }

        if(EventManager.Instance.isFirstPartBossDead == true && EventManager.Instance.finalBossMiddle == false)
        {
            mDirector.Play();
        }

        if (normalizedTime >= 0.01f && normalizedTime < 0.99f)
        {
            PlayerStatus.isDialouging = true;
        }

        if (normalizedTime >= 0.99f)
        {
            PlayerStatus.isDialouging = false;
            EventManager.Instance.finalBossMiddle = true;
        }
    }
}
