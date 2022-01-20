using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DioLogOpen : MonoBehaviour
{
    public GameObject Button;
    public GameObject talkUI;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Button.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Button.SetActive(false);
        talkUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && Button.activeSelf)
        {
            talkUI.SetActive(true);
            PlayerStatus.isDialouging = true;
        }

        
    }
}
