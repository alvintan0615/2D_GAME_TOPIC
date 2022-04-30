using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyCrystal : MonoBehaviour
{
    private int randomHit;
    private int hitCrystal;
    public GameObject crystalBreakSome;
    public GameObject crystalBreakAll;

    public AudioSetting audioSetting;
    private void Start()
    {
        randomHit = Random.Range(2, 4);
        audioSetting = GameObject.Find("SFX").GetComponent<AudioSetting>();
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
                audioSetting.soundEffectAudio[40].Play();
            }
                

            if(hitCrystal >= randomHit)
            {
                GameManager.Instance.playerStats.CurrentHealingTime += 1;
                Instantiate(crystalBreakAll, this.gameObject.transform.position, Quaternion.identity);
                //audio Destory
                audioSetting.soundEffectAudio[41].Play();
                Destroy(this.gameObject);
            }
        }
    }
}
