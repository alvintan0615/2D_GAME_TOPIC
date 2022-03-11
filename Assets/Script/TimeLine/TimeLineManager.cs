using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TimeLineManager : MonoBehaviour
{
    public static TimeLineManager ins;

    public Text dialogueLineText;

    public Image characterCG;

    [SerializeField] PlayableDirector activeDirector;
    private void Awake()
    {
        if (ins != null)
        {
            Destroy(gameObject);
        }
        else
            ins = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResumeTimeline();
        }
    }

    public void SetDialogue(string lineOfDialogue, Sprite CharacterPhoto)
    {
        dialogueLineText.text = lineOfDialogue;
        if (CharacterPhoto != null)
        {
            characterCG.sprite = CharacterPhoto;
            characterCG.gameObject.SetActive(true);
        }
        else
            characterCG = null;

        dialogueLineText.gameObject.SetActive(true);
        
    }

    //暂停TimeLine
    public void PauseTimeline(PlayableDirector whichOne)
    {
        activeDirector = whichOne;

        activeDirector.Pause();
    }

    //恢复播放TimeLine
    public void ResumeTimeline()
    {
        dialogueLineText.gameObject.SetActive(false);
        if(characterCG != null)
            characterCG.gameObject.SetActive(false);
        activeDirector.Resume();
    }
}
