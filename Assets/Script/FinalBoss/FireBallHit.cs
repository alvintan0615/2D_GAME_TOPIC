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
        audioSetting.soundEffectAudio[18].Play();
        audioSetting.soundEffectAudio[18].mute = true;
        StartCoroutine(ReturnPool());
    }

    IEnumerator ReturnPool()
    {
        yield return new WaitForSeconds(1.5f);
        //Dust Audio Mute
        audioSetting.soundEffectAudio[18].mute = false;
        FireBallHitObjectpool.instance.FireBallHitReturnPool(this.gameObject);
    }
}
