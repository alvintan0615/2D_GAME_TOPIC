using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Linq;
public class ChangeDemon : MonoBehaviour
{
    public PlayableDirector mDirector;
    public float normalizedTime;

    [SerializeField] TutorialPanel tutorialPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var timelineAsset = mDirector.playableAsset as TimelineAsset;
        var track1 = timelineAsset.GetOutputTracks().FirstOrDefault(t => t.name == "Player1");
        var track2 = timelineAsset.GetOutputTracks().FirstOrDefault(t => t.name == "Player2");
        var track3 = timelineAsset.GetOutputTracks().FirstOrDefault(t => t.name == "Human1");
        var track4 = timelineAsset.GetOutputTracks().FirstOrDefault(t => t.name == "Human2");
        var track5 = timelineAsset.GetOutputTracks().FirstOrDefault(t => t.name == "Demon1");
        var track6 = timelineAsset.GetOutputTracks().FirstOrDefault(t => t.name == "Demon2");

        normalizedTime = (float)(mDirector.time / mDirector.duration);

        if (GameManager.Instance.playerStats != null)
        {
            mDirector.SetGenericBinding(track1, GameManager.Instance.playerStats.gameObject);
            mDirector.SetGenericBinding(track2, GameManager.Instance.playerStats.gameObject);
            mDirector.SetGenericBinding(track3, GameManager.Instance.playerStats.transform.GetChild(0).gameObject);
            mDirector.SetGenericBinding(track4, GameManager.Instance.playerStats.transform.GetChild(0).gameObject);
            mDirector.SetGenericBinding(track5, GameManager.Instance.playerStats.transform.GetChild(1).gameObject);
            mDirector.SetGenericBinding(track6, GameManager.Instance.playerStats.transform.GetChild(1).gameObject);
        }

        if (GameManager.Instance.playerStats.characterData.currentHealth <= 50 
            && EventManager.Instance.fireVillege_TimelineChangeDemon == false 
            && EventManager.Instance.fireVillege_BossStoryLine == true)
        {
            PlayerStatus.isDialouging = true;
            mDirector.Play();
        }

        if (normalizedTime >= 0.99f && EventManager.Instance.fireVillege_TimelineChangeDemon == false)
        {
            PlayerStatus.isDialouging = false;
            EventManager.Instance.fireVillege_TimelineChangeDemon = true;
            this.gameObject.SetActive(false);
            tutorialPanel.CanOpenDemonPanel = true;
            //StartCoroutine(DelayOpenDemonPanel());
        }
    }

    IEnumerator DelayOpenDemonPanel()
    {
        yield return new WaitForSeconds(1);
        tutorialPanel.CanOpenDemonPanel = true;
    }
}
