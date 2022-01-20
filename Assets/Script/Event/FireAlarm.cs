using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAlarm : MonoBehaviour
{
    public GameObject fireAlarmActive;
    public GameObject villegeTrans, villegeFireTrans;


    void Update()
    {
        if(EventManager.Instance.fireAlarm == true)
        {
            fireAlarmActive.SetActive(true);
            villegeTrans.SetActive(false);
            villegeFireTrans.SetActive(true);
        }
        else
        {
            fireAlarmActive.SetActive(false);
            villegeTrans.SetActive(true);
            villegeFireTrans.SetActive(false);
        }
            
    }
}
