using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;
public class ElectricGroundTrick : MonoBehaviour
{
    public Animator electricDoor;
    public GameObject light2d;
    bool isOpen = false;
    public PathFollower[] pathFollowers; 
    void Start()
    {
        
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
            foreach(var pathFollower in pathFollowers)
            {
                pathFollower.enabled = true;
            }
        }
            
    }
}
