using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallHit : MonoBehaviour
{
    public AudioSetting audioSetting;
    private void Awake()
    {
        audioSetting = GameObject.Find("SFX").GetComponent<AudioSetting>();
    }
    private void OnEnable()
    {

        //Dust Audio play
        StartCoroutine(ReturnPool());
    }

    private void Update()
    {
        if(EventManager.Instance.isFinalBossLetPlayerDead == true || EventManager.Instance.isFirstPartBossDead == true)
            FireBallHitObjectpool.instance.FireBallHitReturnPool(this.gameObject);
    }

    IEnumerator ReturnPool()
    {
        yield return new WaitForSeconds(1.5f);
        FireBallHitObjectpool.instance.FireBallHitReturnPool(this.gameObject);
    }
}
