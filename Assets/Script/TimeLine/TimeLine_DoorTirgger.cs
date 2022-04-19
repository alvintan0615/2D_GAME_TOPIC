using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class TimeLine_DoorTirgger : MonoBehaviour
{
    public PlayableDirector mDirector;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && EventManager.Instance.isGetFinalBossdoorKey == true &&
            EventManager.Instance.isFinalBossDoorOpen == false)
        {
            PlayerStatus.isDialouging = true;
            mDirector.Play();
        }
    }
}
