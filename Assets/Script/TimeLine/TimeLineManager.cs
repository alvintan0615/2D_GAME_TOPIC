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

    public Image _Pannel;

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
        if (Input.GetKeyDown(KeyCode.A))
            {
                ResumeTimeline();
            }
    }

    public void SetDialogue(string lineOfDialogue, Sprite CharacterPhoto, Image Pannel)
    {
        dialogueLineText.text = lineOfDialogue;
        _Pannel = Pannel;
        if (CharacterPhoto != null)
        {
            characterCG.gameObject.SetActive(true);
            characterCG.sprite = CharacterPhoto;
            
        }
        

        dialogueLineText.gameObject.SetActive(true);
        _Pannel.gameObject.SetActive(true);
    }

    //暂停TimeLine
    public void PauseTimeline(PlayableDirector whichOne)
    {
        activeDirector = whichOne;

        activeDirector.playableGraph.GetRootPlayable(0).SetSpeed(0);
    }

    //恢复播放TimeLine
    public void ResumeTimeline()
    {
        dialogueLineText.gameObject.SetActive(false);
        if(characterCG != null)
            characterCG.gameObject.SetActive(false);

        _Pannel.gameObject.SetActive(false);
        activeDirector.playableGraph.GetRootPlayable(0).SetSpeed(1);
    }
}
