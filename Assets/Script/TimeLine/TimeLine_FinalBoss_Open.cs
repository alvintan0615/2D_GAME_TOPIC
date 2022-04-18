using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Linq;
using UnityEngine.Video;
public class TimeLine_FinalBoss_Open : MonoBehaviour
{
    public PlayableDirector mDirector;
    public float normalizedTime;
    public GameObject excuse;

    // Update is called once per frame
    void Update()
    {
        normalizedTime = (float)(mDirector.time / mDirector.duration);

        var timelineAsset = mDirector.playableAsset as TimelineAsset;
        var track1 = timelineAsset.GetOutputTracks().FirstOrDefault(t => t.name == "Player1");
        var track2 = timelineAsset.GetOutputTracks().FirstOrDefault(t => t.name == "Human1");

        if (GameManager.Instance.playerStats != null)
        {
            mDirector.SetGenericBinding(track1, GameManager.Instance.playerStats.gameObject);
            mDirector.SetGenericBinding(track2, GameManager.Instance.playerStats.transform.GetChild(0).gameObject);
        }

        if (normalizedTime >= 0.01f && normalizedTime < 0.99f)
        {
            PlayerStatus.isDialouging = true;
        }

        if (normalizedTime >= 0.99f)
        {
            EventManager.Instance.finalBossOpen = true;
            var video = excuse.GetComponent<VideoPlayer>();
            excuse.SetActive(true);
            video.Play();
        }
    }
}
