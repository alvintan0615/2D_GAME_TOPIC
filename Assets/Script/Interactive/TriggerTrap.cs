using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrap : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public GameObject trans;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            var playerController = player.GetComponent<NewPlayerController>();
            if (playerController.isDead == false)
            {
                player.transform.position = playerController.trapPos.transform.position;
                StartCoroutine(TrapHurt(collision));
            }
        }
    }
    IEnumerator TrapHurt(Collider2D collision)
    {
        Human_Skill.instance.Hurt();
        collision.gameObject.GetComponent<TimeStop>().StopTime(0.05f, 10, 0.1f);
        collision.gameObject.GetComponent<CharacterStats>().TrapDamage(5, 10);
        PlayerStatus.isClimbing = false;
        PlayerStatus.isHurting = false;
        yield return null;
    }
}
