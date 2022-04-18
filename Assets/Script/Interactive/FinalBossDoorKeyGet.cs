using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossDoorKeyGet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            EventManager.Instance.isGetFinalBossdoorKey = true;
            this.gameObject.SetActive(false);
        }
    }
}
