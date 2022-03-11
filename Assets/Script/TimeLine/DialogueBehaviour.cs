using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
public class DialogueBehaviour : PlayableBehaviour
{
    public string dialogueLine;
    public Sprite dialogueCG;
    public Image _pannel;
    public bool hasToPause = false;
    bool clipPlayed = false;
    bool pauseScheduled = false;
    PlayableDirector director;
    public override void OnPlayableCreate(Playable playable)
    {
        Debug.Log("OnPlayableCreate");
        director = playable.GetGraph().GetResolver() as PlayableDirector;
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        Debug.Log("ProcessFrame");

        if (!clipPlayed && info.weight > 0f)
        {
            Debug.Log("ProcessFrame true");
            dialogueLine = dialogueLine.Replace("\\n", "\n");
            TimeLineManager.ins.SetDialogue(dialogueLine, dialogueCG, _pannel);
            
            if (Application.isPlaying && hasToPause)
            {
                pauseScheduled = true;
            }

            clipPlayed = true;
        }
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        if (pauseScheduled)
        {
            pauseScheduled = false;
            TimeLineManager.ins.PauseTimeline(director);
        }
    }
}
