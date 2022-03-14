using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionTrap : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public GameObject trans;
    void Start()
    {

    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            player.transform.position = trans.transform.position;

            StartCoroutine(TrapHurt(collision));
        }
    }

    IEnumerator TrapHurt(Collision2D collision)
    {
        Human_Skill.instance.Hurt();
        collision.gameObject.GetComponent<TimeStop>().StopTime(0.05f, 10, 0.1f);
        collision.gameObject.GetComponent<CharacterStats>().TrapDamage(5, 10);
        yield return null;
    }
}
