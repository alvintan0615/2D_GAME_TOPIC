using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Linq;

public class TimeLine_SewerBossTori : MonoBehaviour
{
    public PlayableDirector mDirector;
    public float normalizedTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var timelineAsset = mDirector.playableAsset as TimelineAsset;
        var track = timelineAsset.GetOutputTracks().FirstOrDefault(t => t.name == "Player");

        if (GameManager.Instance.playerStats != null)
        {
            mDirector.SetGenericBinding(track, GameManager.Instance.playerStats.gameObject);
        }

            normalizedTime = (float)(mDirector.time / mDirector.duration);

        if (EventManager.Instance.Sewer_TimeLineBossTori == true)
            mDirector.Stop();

        if (Application.isPlaying && EventManager.Instance.Dungeon_Opening == false && normalizedTime >= 0.01f && normalizedTime < 0.99f)
        {
            PlayerStatus.isDialouging = true;
        }

        if (normalizedTime >= 0.99f)
        {
            EventManager.Instance.Sewer_TimeLineBossTori = true;
            PlayerStatus.isDialouging = false;

        }
    }
}
