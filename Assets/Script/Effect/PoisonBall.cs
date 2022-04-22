using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBall : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject target;
    public GameObject player;
    public AudioSetting audioSetting;
    private void Awake()
    {
        audioSetting = GameObject.Find("SFX").GetComponent<AudioSetting>();
    }
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        float randomForce = Random.Range(1f, 43f);
        rb.AddForce(Vector2.left* randomForce, ForceMode2D.Impulse);

        target = GameObject.FindGameObjectWithTag("FinalBossP2");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(EventManager.Instance.isFinalBossLetPlayerDead == true)
            PoisonBallObjcetPool.instance.PoisonBallReturnPool(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PoisonBallObjcetPool.instance.PoisonBallReturnPool(this.gameObject);
            PoisonContainerObjectPool.instance.PoisonContainerGetFromPool(this.gameObject.transform.position);
            //Audio PoisonContainer play
            audioSetting.soundEffectAudio[20].Play();
            var bossStats = target.GetComponent<CharacterStats>();
            var playerStats = player.GetComponent<CharacterStats>();
            playerStats.TakeDamage(bossStats, playerStats, 3);
        }

        if (collision.gameObject.layer == 8)
        {
            PoisonBallObjcetPool.instance.PoisonBallReturnPool(this.gameObject);
            PoisonContainerObjectPool.instance.PoisonContainerGetFromPool(this.gameObject.transform.position);
            //Audio PoisonContainer play
            audioSetting.soundEffectAudio[20].Play();
        }
    }
}
