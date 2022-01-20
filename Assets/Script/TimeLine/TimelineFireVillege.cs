using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
public class TimelineFireVillege : MonoBehaviour
{
    public PlayableDirector mDirector;
    public float normalizedTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (mDirector.state == PlayState.Paused)
        {
            EventManager.Instance.CantMove = true;
        }*/


        normalizedTime = (float)(mDirector.time / mDirector.duration);
        if (normalizedTime >= 1f)
        {
            EventManager.Instance.fireVillege_Timeline = true;
            EventManager.Instance.fireVillege_Dialog = true;
            //TODO TimelineFinished
            /*EventManager.Instance.dialogFlowchart.SendFungusMessage("TimelineFinished");*/
        }
        else
            EventManager.Instance.fireVillege_Timeline = false;

        if(mDirector.state == PlayState.Playing)
        {
            PlayerStatus.isDialouging = true;
        }
        /*if(normalizedTime != mDirector.duration && mDirector.state == PlayState.Playing)
        {
            EventManager.Instance.CantMove = true;
        }
        else
        {
            EventManager.Instance.CantMove = false;
        }*/
        if(EventManager.Instance.fireVillege_Timeline == true)
        {
            this.gameObject.SetActive(false);
            PlayerStatus.isDialouging = false;
            //Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ("Player"))
        {
            
            mDirector.Play();
        }
    }
}
