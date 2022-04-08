using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronChainCollider : MonoBehaviour
{
    public AudioSource ironChain;
    public bool canPlaySound = false;
    // Start is called before the first frame update
    void Start()
    {
        canPlaySound = false;
        ironChain.mute = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlaySound == true)
        {
            ironChain.mute = false;
        }
        else
        {
            ironChain.mute = true;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        canPlaySound = true;
    //    }
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
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
