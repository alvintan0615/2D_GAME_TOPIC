using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CineMachineZoomInOut : MonoBehaviour
{
    
    void Start()
    {
        this.GetComponent<CinemachineVirtualCamera>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            this.GetComponent<CinemachineVirtualCamera>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            this.GetComponent<CinemachineVirtualCamera>().enabled = false;
    }
}
