using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss_SecondPart : MonoBehaviour
{
    public GameObject electricBall;
    private GameObject electricBallPos;
    public GameObject knockBackLight;
    private GameObject knockBackLightPos;
    private GameObject player;
    private Animator anim;
    public bool isUnder60;
    private CharacterStats characterStats;
    public float sightRadius;
    public GameObject attackTarget;
    private bool isKnockBackHit = false;
    private void OnEnable()
    {
        electricBallPos = transform.GetChild(2).gameObject;
        knockBackLightPos = transform.GetChild(3).gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        characterStats = GetComponent<CharacterStats>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        foundPlayer();

        if(characterStats.CurrentHealth < characterStats.MaxHealth* 0.6f)
            isUnder60 = true;

    }

    public void RandomPickstate()
    {
        if(isUnder60 == false && EventManager.Instance.isFirstPartBossDead == true)
        {
            float randomPick = Random.Range(0, 3);
            if (randomPick == 0)
                anim.SetTrigger("Poison");
            if (randomPick == 1)
                anim.SetTrigger("ThrowElectricBall");
            if(randomPick == 2 && foundPlayer() == true)
            {
                anim.SetTrigger("CloseAttack");
            }else if(randomPick == 2 && foundPlayer() == false)
            {
                randomPick = Random.Range(0, 2);
                if (randomPick == 0)
                    anim.SetTrigger("Poison");
                if (randomPick == 1)
                    anim.SetTrigger("ThrowElectricBall");
            }
        }

        if (isUnder60 == true && EventManager.Instance.isFirstPartBossDead == true)
        {
            float randomPick = Random.Range(0, 5);
            if (randomPick == 0)
            {
                anim.SetTrigger("Poison");
                isKnockBackHit = false;
            }
                
            if (randomPick == 1)
            {
                anim.SetTrigger("ThrowElectricBall");
                isKnockBackHit = false;
            }
                
            if (randomPick == 2)
            {
                anim.SetTrigger("Poison2");
                isKnockBackHit = false;
            }
                
            if (randomPick == 3 && isKnockBackHit == false)
            {
                anim.SetTrigger("KnockBackHit");
                isKnockBackHit = true;
            }
                
            if (randomPick == 4 && foundPlayer() == true)
            {
                anim.SetTrigger("CloseAttack");
                isKnockBackHit = true;
            }
            else if (randomPick == 4 && foundPlayer() == false)
            {
                randomPick = Random.Range(0, 4);
                if (randomPick == 0)
                {
                    anim.SetTrigger("Poison");
                    isKnockBackHit = false;
                }
                if (randomPick == 1)
                {
                    anim.SetTrigger("ThrowElectricBall");
                    isKnockBackHit = false;
                }
                if (randomPick == 2)
                {
                    anim.SetTrigger("Poison2");
                    isKnockBackHit = false;
                }
                if (randomPick == 3 && isKnockBackHit == false)
                {
                    anim.SetTrigger("KnockBackHit");
                    isKnockBackHit = true;
                }
            }
        }

    }

    bool foundPlayer()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, sightRadius);

        foreach (var target in colliders)
        {
            if (target.CompareTag("Player"))
            {
                attackTarget = target.gameObject;
                return true;
            }
        }
        attackTarget = null;
        return false;
    }


    public void CreateElectricBall()
    {
        Instantiate(electricBall, electricBallPos.transform.position, Quaternion.identity);
    }

    public void CreateknockBackLight()
    {
        Instantiate(knockBackLight, knockBackLightPos.transform.position, Quaternion.identity);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRadius);
    }
}
