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

   
}
