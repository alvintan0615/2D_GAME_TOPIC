using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvasController : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.Instance.StopPanel = true;
    }

    private void OnDisable()
    {
        GameManager.Instance.StopPanel = false;
    }
}
