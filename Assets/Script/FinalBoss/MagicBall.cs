using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    public GameObject target;
    public GameObject player;
    public float distance;
    Vector3 dir;
    private bool isAttack = false;
    public float isAttackTime;
    private bool hasPlayerPosition;
    private Vector3 playerPosition;
    public float ballSpeed;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("FinalBoss_FirstPart");
        player = GameObject.FindGameObjectWithTag("Player");
        dir = transform.position - target.transform.position;
    }

    
    void Update()
    {
        StartCoroutine(BoolMagicBallAttack(isAttackTime));

        if (isAttack == false)
        {
            MagicBallAround();
        }
        else
        {
            MagicBallAttack();
        }
        
    }

    void MagicBallAround()
    {
            transform.position = target.transform.position + dir.normalized * distance;
            transform.RotateAround(target.transform.position, Vector3.forward, 50 * Time.deltaTime);
            dir = transform.position - target.transform.position;
    }

    void MagicBallAttack()
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

    IEnumerator BoolMagicBallAttack(float isAttackTime)
    {
        yield return new WaitForSeconds(isAttackTime);
        isAttack = true;
        yield return new WaitForSeconds(4f);
        MagicBallObjectpool.instance.ReturnPool(this.gameObject);
    }
}
