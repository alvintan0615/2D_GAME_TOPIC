using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Linq;
public class TimeLine_HereWeGoAgain : MonoBehaviour
{
    public PlayableDirector mDirector;
    public float normalizedTime;
    public GameObject bossp1;

    void Update()
    {
        normalizedTime = (float)(mDirector.time / mDirector.duration);


        if (normalizedTime >= 0.01f && normalizedTime < 0.99f)
        {
            PlayerStatus.isDialouging = true;
            if(GameManager.Instance.Ken_Human == true)
                NewPlayerController.instance.animator[0].Play("Human_IdleRun");
            else
                NewPlayerController.instance.animator[1].Play("Demon_IdleRun");

            bossp1.SetActive(true);
            EventManager.Instance.isFirstPartBossDead = false;
            EventManager.Instance.finalBossMiddle = false;
        }

        if (normalizedTime >= 0.99f)
        {
            PlayerStatus.isDialouging = false;
            EventManager.Instance.isFinalBossLetPlayerDead = false;
            EventManager.Instance.isPlayerPosOK = false;
        }
    }
}
