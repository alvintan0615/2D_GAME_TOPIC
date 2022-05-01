using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineMachineFollowPlayer : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera followCamera;
    [SerializeField]private float timer;
    [SerializeField] private bool isOK = false;
    private void Start()
    {
        followCamera = GetComponent<CinemachineVirtualCamera>();
        if(GameManager.Instance.playerStats != null)
        {
            followCamera.Follow = GameManager.Instance.playerStats.transform;
        }
    }

    private void Update()
    {
        if(isOK == false)
        {
            followCamera.Follow = GameManager.Instance.playerStats.transform;
            timer += Time.deltaTime;
            if (timer >= 3f)
            {
                isOK = true;
                timer = 0f;

            }
        }

    }
}
