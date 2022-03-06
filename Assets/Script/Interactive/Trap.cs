using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Trap : MonoBehaviour
{
    [SerializeField] float time = 2f;
    private void OnTriggerStay2D(Collider2D collision)
    {
        time += Time.deltaTime;

        if(time > 1.5f)
        {
            if (collision.gameObject.tag == "Player")
            {
                time = 0f;
                Human_Skill.instance.Hurt();
                collision.gameObject.GetComponent<TimeStop>().StopTime(0.05f, 10, 0.1f);
                collision.gameObject.GetComponent<CharacterStats>().TrapDamage(5, 10);
            }
        }


        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<CharacterStats>().TrapDamage(9999, 9999);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            time = 2f;
    }
}
