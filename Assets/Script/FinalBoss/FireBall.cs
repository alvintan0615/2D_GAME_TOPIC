using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject meteorHit;
    public GameObject target;
    public GameObject player;
    public AudioSetting audioSetting;

    private void Awake()
    {
        audioSetting = GameObject.Find("SFX").GetComponent<AudioSetting>();
    }
    void OnEnable()
    {
        target = GameObject.FindGameObjectWithTag("FinalBoss_FirstPart");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(EventManager.Instance.isFinalBossLetPlayerDead == true || EventManager.Instance.isFirstPartBossDead == true)
        {
            audioSetting.soundEffectAudio[18].mute = true;
            FireBallObjectpool.instance.FireBallReturnPool(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FireBallHitObjectpool.instance.FireBallHitGetFromPool(this.gameObject.transform.position);
            audioSetting.soundEffectAudio[18].Play();
            FireBallObjectpool.instance.FireBallReturnPool(this.gameObject);
            var bossStats = target.GetComponent<CharacterStats>();
            var playerStats = player.GetComponent<CharacterStats>();
            playerStats.TakeDamage(bossStats, playerStats, 7);
        }
        if (collision.gameObject.layer == 8)
        {
            FireBallHitObjectpool.instance.FireBallHitGetFromPool(this.gameObject.transform.position);
            audioSetting.soundEffectAudio[18].Play();
            FireBallObjectpool.instance.FireBallReturnPool(this.gameObject);
        }
    }

}
