using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneHitOnSound : MonoBehaviour
{
    public AudioSource StoneHit;
    public bool canPlaySound = false;
    // Start is called before the first frame update
    void Start()
    {
        canPlaySound = false;
        StoneHit.mute = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canPlaySound == true)
        {
            StoneHit.mute = false;
        }
        else
        {
            StoneHit.mute = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canPlaySound = true;
            StoneHit.mute = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canPlaySound = false;
            StoneHit.mute = true;
        }
    }

    public void StoneHitSound()
    {
        StoneHit.Play();
    }
}
