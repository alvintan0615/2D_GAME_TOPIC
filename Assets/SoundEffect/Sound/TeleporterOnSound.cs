using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterOnSound : MonoBehaviour
{
    public AudioSource TeleporterSound;
    public bool canPlaySound = false;
    // Start is called before the first frame update
    void Start()
    {
        TeleporterSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlaySound == true)
        {

            TeleporterSound.mute = false;
        }
        else
        {
            TeleporterSound.mute = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            canPlaySound = true;
            TeleporterSound.mute = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canPlaySound = false;
            TeleporterSound.mute = true;
        }
    }
}
