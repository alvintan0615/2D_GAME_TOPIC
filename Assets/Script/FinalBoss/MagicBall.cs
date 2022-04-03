using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    public GameObject target;
    Vector3 targetPos;
    public GameObject player;
    public float distance;
    Vector3 dir;
    private bool isAttack = false;
    public float isAttackTime;
    private bool hasPlayerPosition;
    private Vector3 playerPosition;
    public float ballSpeed;
    float r;
    public int number;
    public bool isSpiralAttack = false;
    void OnEnable()
    {
        target = GameObject.FindGameObjectWithTag("FinalBoss_FirstPart");
        player = GameObject.FindGameObjectWithTag("Player");
        int randomPick = Random.Range(5, 10);
        dir = transform.position - target.transform.position;
        targetPos = target.transform.position;
    }

    
    void Update()
    {
        StartCoroutine(BoolMagicBallAttack(isAttackTime));

        if (isAttack == false )
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
            transform.RotateAround(target.transform.position, Vector3.forward, 90 * Time.deltaTime);
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
        yield return new WaitForSeconds(3f);
        isAttack = false;
        hasPlayerPosition = false;
        MagicBallObjectpool.instance.ReturnPool(this.gameObject);
    }
}
