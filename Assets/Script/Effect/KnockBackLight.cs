using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackLight : MonoBehaviour
{
    private bool isTouchPlayer = false;
    private bool isPlayerAttack = true;
    private GameObject p2Boss;
    private void Start()
    {
        p2Boss = GameObject.FindGameObjectWithTag("FinalBossP2");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isTouchPlayer == false && isPlayerAttack == true)
        {
            var playerCS = collision.GetComponent<CharacterStats>();
            var p2BossCS = p2Boss.GetComponent<CharacterStats>();
            playerCS.TakeDamage(p2BossCS, playerCS, 5);

        }

        if (collision.gameObject.tag == "Player" && isTouchPlayer == false && isPlayerAttack == false)
        {
            isTouchPlayer = true;
            var playerRb = collision.GetComponent<Rigidbody2D>();
            Human_Skill.instance.Hurt();
            //playerRb.AddForce(Vector2.up * 3000);
            playerRb.AddForce(new Vector2(-1 * 100000, 1 * 2000));
            
        }
    }

    public void PlayerAttack()
    {
        isPlayerAttack = false;
    }

    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
