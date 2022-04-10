using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class ElectricTimeLineTrick : MonoBehaviour
{
    public PlayableDirector mDirector;
    public bool isTimeLineOK = false;
    public GameObject light2d;
    [SerializeField]private bool isOpen;
    void Update()
    {
        if (isOpen == false)
            light2d.SetActive(false);
        else
        {
            light2d.SetActive(true);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && EventManager.Instance.electricDoor == true && isTimeLineOK == false)
        {
            isOpen = true;
            mDirector.Play();
            isTimeLineOK = true;
        }
    }
}
