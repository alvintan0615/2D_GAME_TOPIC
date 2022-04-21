using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class Trigger_HereWeGoAgain : MonoBehaviour
{
    public PlayableDirector mDirector;
    public GameObject boss1;
    public GameObject boss2;
    public GameObject cam1;
    public GameObject cam2;
    void Update()
    {
        if (EventManager.Instance.finalBossStart == true && NewPlayerController.instance.isDead == true)
        {
            EventManager.Instance.isFinalBossLetPlayerDead = true;
            StartCoroutine(SetReturn());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && EventManager.Instance.isFinalBossLetPlayerDead == true)
        {
            mDirector.Play();
        }
    }

    IEnumerator SetReturn()
    {
        yield return new WaitForSeconds(2f);

        boss1.SetActive(false);
        boss2.SetActive(false);
        cam1.SetActive(true);
        cam2.SetActive(false);
    }
}
