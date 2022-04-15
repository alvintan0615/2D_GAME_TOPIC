using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterOnSound : MonoBehaviour
{
    public AudioSource TeleporterSound;
    //public bool canPlaySound = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //canPlaySound = true;
            TeleporterSound.mute = false;
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        canPlaySound = true;
    //        TeleporterSound.mute = false;
    //    }
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //canPlaySound = false;
            TeleporterSound.mute = true;
        }
    }
}
