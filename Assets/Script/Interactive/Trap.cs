using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Trap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<TimeStop>().StopTime(0.05f, 10, 0.1f);
            collision.gameObject.GetComponent<CharacterStats>().TrapDamage(5,10);
        }

        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<CharacterStats>().TrapDamage(9999, 9999);
        }
    }
}
