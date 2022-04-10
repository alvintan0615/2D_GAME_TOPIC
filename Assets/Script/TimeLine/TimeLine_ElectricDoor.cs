using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Linq;

public class TimeLine_ElectricDoor : MonoBehaviour
{
    public PlayableDirector mDirector;
    public float normalizedTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        normalizedTime = (float)(mDirector.time / mDirector.duration);

        if (normalizedTime >= 0.01f && normalizedTime < 0.99f)
        {
            PlayerStatus.isDialouging = true;
        }

        if (normalizedTime >= 0.99f)
        {
            PlayerStatus.isDialouging = false;
        }
    }
}
