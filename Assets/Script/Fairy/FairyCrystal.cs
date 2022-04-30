using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyCrystal : MonoBehaviour
{
    private int randomHit;
    private int hitCrystal;
    public GameObject crystalBreakSome;
    public GameObject crystalBreakAll;
    private void Start()
    {
        randomHit = Random.Range(2, 4);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "AttackTrigger")
        {
            if(hitCrystal < randomHit)
            {
                hitCrystal += 1;
                Instantiate(crystalBreakSome, this.gameObject.transform.position, Quaternion.identity);
                //Audio Hit
            }
                

            if(hitCrystal >= randomHit)
            {
                GameManager.Instance.playerStats.CurrentHealingTime += 1;
                Instantiate(crystalBreakAll, this.gameObject.transform.position, Quaternion.identity);
                //audio Destory
                Destroy(this.gameObject);
            }
        }
    }
}
