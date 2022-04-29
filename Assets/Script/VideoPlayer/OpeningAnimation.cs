using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class OpeningAnimation : MonoBehaviour
{
    [SerializeField] private VideoPlayer openingAnimation;
    public double currentTime;
    public double totalTime;
    void Awake()
    {
        openingAnimation = GetComponent<VideoPlayer>();
        openingAnimation.loopPointReached += TransToFirstLevel;
    }
    
    /*void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= totalTime)
        {
            
        }
    }*/

    void TransToFirstLevel(UnityEngine.Video.VideoPlayer vp)
    {
        SceneController.Instance.TransitionToFirstLevel();
    }
}
