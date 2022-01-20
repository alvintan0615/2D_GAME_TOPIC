using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectActiveFalse : MonoBehaviour
{
    void SetActive()
    {
        this.gameObject.SetActive(false);
        Destroy(gameObject);
    }

}
