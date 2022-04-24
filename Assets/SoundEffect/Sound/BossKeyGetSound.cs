using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKeyGetSound : MonoBehaviour
{
    public AudioSetting audioSetting;
    static public bool KeyHasGet = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSetting = GameObject.Find("SFX").GetComponent<AudioSetting>();
        KeyHasGet = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSetting.soundEffectAudio[35].Play();
            audioSetting.soundEffectAudio[36].mute = true;
            KeyHasGet = true;
        }
    }
}
