using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricGroundTrick : MonoBehaviour
{
    public Animator electricDoor;
    [SerializeField] private GameObject light2d;
    bool isOpen = false;
    void Start()
    {
        light2d = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        if (isOpen == false)
            light2d.SetActive(false);
        else
            light2d.SetActive(true);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && EventManager.Instance.electricDoor == true)
        {
            isOpen = true;
            electricDoor.SetTrigger("true");
        }
            
    }
}
