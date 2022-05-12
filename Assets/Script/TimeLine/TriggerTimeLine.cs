using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class TriggerTimeLine : MonoBehaviour
{
    public PlayableDirector mDirector;
    public GameObject tori;
    public GameObject tori_Door1;
    public GameObject tori_Door2;
    public GameObject bossArea;
    public GameObject cam1;
    public GameObject cam2;
    private void Update()
    {
        if(EventManager.Instance.Sewer_TimeLineBossTori == true && NewPlayerController.instance.isDead == true)
        {
            EventManager.Instance.Sewer_TimeLineBossTori = false;
            //var toriScript = tori.GetComponent<Boss_Tori>();
            StartCoroutine(SetReturn());
        }

        if(EventManager.Instance.Sewer_TimeLineBossTori == true && EventManager.Instance.isTori_SewerDead == true)
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && EventManager.Instance.Sewer_TimeLineBossTori == false && NewPlayerController.instance.isDead == false)
        {
            mDirector.Play(); 
        }
    }

    IEnumerator SetReturn()
    {
        yield return new WaitForSeconds(2f);

        tori.SetActive(false);
        tori_Door1.SetActive(false);
        tori_Door2.SetActive(false);
        bossArea.SetActive(false);
        cam1.SetActive(true);
        cam2.SetActive(false);
    }
}
