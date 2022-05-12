using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimationToMain : MonoBehaviour
{
    private void OnEnable()
    {
        SceneController.Instance.TransitionToMain();
    }
}
