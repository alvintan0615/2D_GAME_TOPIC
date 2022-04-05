using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPushOnSound : MonoBehaviour
{
    public AudioSource WaterSound;
    public bool canPlaySound = false;
    // Start is called before the first frame update
    void Start()
    {
        canPlaySound = false;
        WaterSound.mute = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canPlaySound == true)
        {
            WaterSound.mute = false;
        }
        else
        {
            WaterSound.mute = true;
        }

    }

    public void WaterPushSound()
    {
        WaterSound.Play();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canPlaySound = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canPlaySound = false;
        }
    }
}
