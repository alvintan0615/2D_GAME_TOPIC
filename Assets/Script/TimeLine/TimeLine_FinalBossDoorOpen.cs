using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Linq;

public class TimeLine_FinalBossDoorOpen : MonoBehaviour
{
    public PlayableDirector mDirector;
    public float normalizedTime;

    void Update()
    {
        normalizedTime = (float)(mDirector.time / mDirector.duration);


        if (normalizedTime >= 0.01f && normalizedTime < 0.99f)
        {
            PlayerStatus.isDialouging = true;
        }

        if(normalizedTime >= 0.85f)
        {
            if (GameManager.Instance.playerStats != null)
            {
                GameManager.Instance.playerStats.CurrentHealingTime = 3;
            }
        }

        if (normalizedTime >= 0.99f)
        {
            PlayerStatus.isDialouging = false;
            EventManager.Instance.isFinalBossDoorOpen = true;
            
        }
    }
}
