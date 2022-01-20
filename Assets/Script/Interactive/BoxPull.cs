using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FixedJoint2D))]
public class BoxPull : MonoBehaviour
{
    public bool beingPushed;
    float xPos;
    void Start()
    {
        GetComponent<FixedJoint2D>().enabled = false;
        xPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(beingPushed == false)
        {
            transform.position = new Vector3(xPos, transform.position.y);
        }
        else
        {
            xPos = transform.position.x;
        }
    }
}
