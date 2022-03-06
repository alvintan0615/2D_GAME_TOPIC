using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThronAttack : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxColl;
    [SerializeField] private Animator anim;
    [SerializeField] float time = 2f;
    void Start()
    {
        boxColl = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        time += Time.deltaTime;

        if(time > 1.5f)
        {
            if (coll.gameObject.tag == "Player")
            {
                time = 0f;
                Debug.Log(123);
                Human_Skill.instance.Hurt();
                coll.gameObject.GetComponent<TimeStop>().StopTime(0.05f, 10, 0.1f);
                var playerStats = coll.gameObject.GetComponent<CharacterStats>();
                playerStats.ThronDamage(5, playerStats);
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            time = 2f;
    }
}
