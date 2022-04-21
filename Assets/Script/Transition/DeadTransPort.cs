using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTransPort : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var playerController = collision.gameObject.GetComponent<NewPlayerController>();
            playerController.deadPos = this.gameObject;
        }
    }
}
