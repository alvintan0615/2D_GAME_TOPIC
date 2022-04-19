using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class TriggerTimeLine : MonoBehaviour
{
    public PlayableDirector mDirector;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && EventManager.Instance.Sewer_TimeLineBossTori == false)
        {
            mDirector.Play(); 
        }
    }
}
