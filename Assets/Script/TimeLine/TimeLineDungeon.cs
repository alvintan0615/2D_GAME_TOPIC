using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Linq;
public class TimeLineDungeon : MonoBehaviour
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
        var track1 = timelineAsset.GetOutputTracks().FirstOrDefault(t => t.name == "Player1");
        var track2 = timelineAsset.GetOutputTracks().FirstOrDefault(t => t.name == "Human");
        var track3 = timelineAsset.GetOutputTracks().FirstOrDefault(t => t.name == "Human1");
        var track4 = timelineAsset.GetOutputTracks().FirstOrDefault(t => t.name == "Demon");
        var track5 = timelineAsset.GetOutputTracks().FirstOrDefault(t => t.name == "Demon1");

        normalizedTime = (float)(mDirector.time / mDirector.duration);

        if (EventManager.Instance.Dungeon_Opening == true)
            mDirector.Stop();

        if (Application.isPlaying && EventManager.Instance.Dungeon_Opening == false && normalizedTime >= 0.01f && normalizedTime < 0.99f)
        {
            PlayerStatus.isDialouging = true;
        }

        if(normalizedTime >= 0.99f)
        {
            EventManager.Instance.Dungeon_Opening = true;
            PlayerStatus.isDialouging = false;
            
        }
    }
}
