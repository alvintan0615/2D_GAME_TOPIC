using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAnimationToFirstLevel : MonoBehaviour
{
    private void OnEnable()
    {
        SceneController.Instance.TransitionToFirstLevel();
    }
}
