using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_PoisonBall : MonoBehaviour
{
    public AudioSetting audioSetting;
    private Rigidbody2D rb;
    public float fireDir;
    private void Awake()
    {
        audioSetting = GameObject.Find("SFX").GetComponent<AudioSetting>();
    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        float randomForce = Random.Range(16f,20f);
        rb.AddForce(new Vector2(fireDir * randomForce, 13) , ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PoisonBallObjcetPool.instance.PoisonBallReturnPool(this.gameObject);
            PoisonContainerObjectPool.instance.PoisonContainerGetFromPool(this.gameObject.transform.position);
            Human_Skill.instance.Hurt();
            //TODO audio
            audioSetting.soundEffectAudio[22].Play();
            collision.gameObject.GetComponent<TimeStop>().StopTime(0.05f, 10, 0.1f);
            var playerStats = collision.gameObject.GetComponent<CharacterStats>();
            int randomDamage = Random.Range(5, 9);
            playerStats.ThronDamage(randomDamage, playerStats, 5);
        }

        if (collision.gameObject.layer == 8)
        {
            PoisonBallObjcetPool.instance.PoisonBallReturnPool(this.gameObject);
            PoisonContainerObjectPool.instance.PoisonContainerGetFromPool(this.gameObject.transform.position);
            //TODO audio
            audioSetting.soundEffectAudio[22].Play();
        }
    }
}
