using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Linq;

public class TimeLineForestTutorial : MonoBehaviour
{
    public PlayableDirector mDirector;
    public float normalizedTime;

    public bool NowInTutorial = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        normalizedTime = (float)(mDirector.time / mDirector.duration);

        if (EventManager.Instance.PassTutorial == true)
        {
            mDirector.Stop();
        }
         
        if(Application.isPlaying && EventManager.Instance.PassTutorial == false && normalizedTime >= 0.01f && normalizedTime < 0.99f)
        {
            PlayerStatus.isDialouging = true;
            EventManager.Instance.HasFirstTalk = true;
        }

        if (Application.isPlaying && EventManager.Instance.PassTutorial == false && EventManager.Instance.HasFirstTalk == true && normalizedTime >= 0.01f && normalizedTime < 0.99f)
        {
            PlayerStatus.isDialouging = true;
            NowInTutorial = true;
            EventManager.Instance.firstNormalAtk = true;
        }

        if (normalizedTime >= 0.99f)
        {
            EventManager.Instance.PassTutorial = true;
            PlayerStatus.isDialouging = false;

        }
    }
}
