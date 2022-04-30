using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBreak : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(this.gameObject, 2f);
    }
}
