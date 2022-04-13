using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonContainer : MonoBehaviour
{

    private void OnEnable()
    {
        StartCoroutine(ReturnPool());
    }

    IEnumerator ReturnPool()
    {
        yield return new WaitForSeconds(1.5f);
        PoisonContainerObjectPool.instance.PoisonContainerReturnPool(this.gameObject);
    }
}
