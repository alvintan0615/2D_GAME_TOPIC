﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnPlayer : MonoBehaviour
{
    public AudioSetting audioSetting;

    // Start is called before the first frame update
    void Start()
    {
        audioSetting = GameObject.Find("SFX").GetComponent<AudioSetting>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region SkillFunction
    public void HumanNormalAtk01()
    {
        audioSetting.soundEffectAudio[0].Play();
    }

    public void HumanNormalAtk02()
    {
        audioSetting.soundEffectAudio[1].Play();
    }

    public void HumanNormalAtk03()
    {
        audioSetting.soundEffectAudio[2].Play();
    }

    public void HumanFireSkill()
    {
        audioSetting.soundEffectAudio[3].Play();
    }

    public void HumanGroundSkill()
    {
        audioSetting.soundEffectAudio[4].Play();
    }

    public void HumanChangeMode()
    {
        audioSetting.soundEffectAudio[5].Play();
    }

    public void DemonNormalAtk()
    {
        audioSetting.soundEffectAudio[6].Play();
    }

    public void DemonMagicAtk()
    {
        audioSetting.soundEffectAudio[7].Play();
    }

    public void DemonFullSkill()
    {
        audioSetting.soundEffectAudio[8].Play();
    }
    #endregion
}
