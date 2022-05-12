using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToFinalAnimation : MonoBehaviour
{
    private void OnEnable()
    {
        if(EventManager.Instance.finalBossP2isDead == true)
        {
            PlayerStatus.isDialouging = true;
            SceneController.Instance.LoadFinalAnimation();
        }
    }
}
