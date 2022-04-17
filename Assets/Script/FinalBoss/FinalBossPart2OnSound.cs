using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossPart2OnSound : MonoBehaviour
{
    public AudioSetting audioSetting;
    // Start is called before the first frame update

    private void Awake()
    {
        audioSetting = GameObject.Find("SFX").GetComponent<AudioSetting>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PoisonAtkSound()
    {
        audioSetting.soundEffectAudio[19].Play();
    }

    public void PoisonExplosionSound()
    {
        audioSetting.soundEffectAudio[20].Play();
    }

    public void CloseAtkSound()
    {
        audioSetting.soundEffectAudio[21].Play();
    }

    public void KnockBackHitSound()
    {
        audioSetting.soundEffectAudio[22].Play();
    }

    public void CreateEletricBallSound()
    {
        audioSetting.soundEffectAudio[23].mute = false;
        audioSetting.soundEffectAudio[23].Play();
    }

    public void MuteCreateEletricBallSound()
    {
        StartCoroutine(DelayMuteCreateEletricBallSound());
    }

    public void ThrowEletricBallSound()
    {
        audioSetting.soundEffectAudio[24].Play();
    }

    IEnumerator DelayMuteCreateEletricBallSound()
    {
        yield return new WaitForSeconds(1);
        audioSetting.soundEffectAudio[23].mute = true;
    }
}
