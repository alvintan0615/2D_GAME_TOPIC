using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSelfOpen : MonoBehaviour
{
    public GameObject dialogGameObject;
    public GameObject talkUI;
    void Start()
    {
        
    }

    
    void Update()
    {

        if (EventManager.Instance.fireVillege_Dialog == true && !dialogGameObject.activeSelf)
        {
            if(talkUI.name == "Dialog")
            {
                PlayerStatus.isDialouging = true;
                talkUI.SetActive(true);
            }
            
        }
        if (EventManager.Instance.fireVillege_TimelineBeforeToriBoss == true 
&& EventManager.Instance.fireVillege_DialogBeforeToriBoss == false && !dialogGameObject.activeSelf)
        {
            if(talkUI.name == "fireVillege_DialogBeforeToriBoss")
            {
                PlayerStatus.isDialouging = true;
                talkUI.SetActive(true);
            }
            
            //PlayerStatus.isDialouging = false;
        }

        if (talkUI.activeSelf)
        {
            PlayerStatus.isDialouging = true;
        }
    }
}
