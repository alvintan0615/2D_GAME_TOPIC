using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionSound : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            audioSetting.soundEffectAudio[34].Play();
        }
    }
}
