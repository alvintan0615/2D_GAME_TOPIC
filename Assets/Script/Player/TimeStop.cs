using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    private float speed;
    private bool restoreTime;
    void Start()
    {
        restoreTime = false;
    }

    void Update()
    {
        if (restoreTime)
        {
            if(Time.timeScale < 1f)
            {
                Time.timeScale += Time.deltaTime * speed;
            }
            else
            {
                Time.timeScale = 1f;
                restoreTime = false;
            }
        }
    }


    public void StopTime(float ChangeTime, int RestoreSpeed, float Delay)
    {
        speed = RestoreSpeed;

        if(Delay > 0)
        {
            StopCoroutine(StartTimeAgain(Delay));
            StartCoroutine(StartTimeAgain(Delay));
        }
        else
        {
            restoreTime = true;
        }

        Time.timeScale = ChangeTime;
    }

    IEnumerator StartTimeAgain(float amt)
    {
        yield return new WaitForSecondsRealtime(amt);
        restoreTime = true;
    }
}
