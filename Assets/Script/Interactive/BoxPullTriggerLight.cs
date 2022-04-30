using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPullTriggerLight : MonoBehaviour
{
    [SerializeField]private BoxPull boxPull;
    [SerializeField]private GameObject light2d;
    void Start()
    {
        light2d = this.gameObject.transform.parent.GetChild(0).gameObject;
        boxPull = this.gameObject.transform.parent.GetComponent<BoxPull>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && boxPull.beingPushed == false)
        {
            light2d.SetActive(true);
        }

        if (collision.gameObject.tag == "Player" && boxPull.beingPushed == true)
        {
            light2d.SetActive(false);
        }

        if (collision.gameObject.tag == "PoisonWater" && boxPull.beingPushed == false)
        {
            boxPull.isCollPosionWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            light2d.SetActive(false);
        }
        if (collision.gameObject.tag == "PoisonWater" && boxPull.beingPushed == false)
        {
            boxPull.isCollPosionWater = false;
        }
    }
}
