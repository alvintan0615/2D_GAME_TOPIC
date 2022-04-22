using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBall : MonoBehaviour
{
    private GameObject p2Boss;
    private GameObject player;
    private bool hasPlayerPosition;
    private Vector3 playerPosition;
    public float ballSpeed;
    [SerializeField]private bool isAttack = false;
    void Start()
    {
        p2Boss = GameObject.FindGameObjectWithTag("FinalBossP2");
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(ElectricBallFire());
    }

    void Update()
    {
        if(EventManager.Instance.isFinalBossLetPlayerDead == true)
            Destroy(this.gameObject);

        if (isAttack == true)
        {
            ElectricBallAttack();
        }
    }

    void ElectricBallAttack()
    {
        if (!hasPlayerPosition)
        {
            playerPosition = player.transform.position - transform.position;
            playerPosition.Normalize();
            hasPlayerPosition = true;
        }
        if (hasPlayerPosition)
        {
            transform.position += playerPosition * ballSpeed;
        }
    }

    IEnumerator ElectricBallFire()
    {
        yield return new WaitForSeconds(1.1f);
        isAttack = true;
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && isAttack == true)
        {
            Destroy(this.gameObject);
            var bossStats = p2Boss.GetComponent<CharacterStats>();
            var playerStats = player.GetComponent<CharacterStats>();
            playerStats.TakeDamage(bossStats, playerStats, 0);
        }

        if(collision.gameObject.layer == 8 && isAttack == true)
        {
            Destroy(this.gameObject);
        }
    }
}
