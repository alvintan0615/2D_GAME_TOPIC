using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryUI : MonoBehaviour
{
    private bool onEnable = false;
    private float onEnableTimer;
    private float onEnableCD = 10f;
    private void OnEnable()
    {
       // SlowDestory();
    }
    private void Start()
    {
        
    }

    void SlowDestory()
    {

    }

    /*IEnumerator SlowDestory()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }*/
}
