using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTransPort : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            var playerController = collision.gameObject.GetComponent<NewPlayerController>();
            playerController.trapPos = this.gameObject;
        }
    }
}
