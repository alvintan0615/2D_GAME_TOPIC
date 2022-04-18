using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Linq;
public class TimeLine_FinalBoss_Next : MonoBehaviour
{
    public PlayableDirector mDirector;
    public float normalizedTime;
    void Start()
    {
        
    }

    void Update()
    {
        normalizedTime = (float)(mDirector.time / mDirector.duration);

        if(EventManager.Instance.finalbossExcuseVideo == true && EventManager.Instance.finalBossStart == false)
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
            EventManager.Instance.finalBossStart = true;
        }
    }
}
