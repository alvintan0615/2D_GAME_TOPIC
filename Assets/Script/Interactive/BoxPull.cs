using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FixedJoint2D))]
public class BoxPull : MonoBehaviour
{
    public bool beingPushed;
    public bool isCollPosionWater;
    float xPos;
    void Start()
    {
        GetComponent<FixedJoint2D>().enabled = false;
        xPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(beingPushed == false && isCollPosionWater == false)
            transform.position = new Vector3(xPos, transform.position.y);
        else if (beingPushed == true && isCollPosionWater == false)
            xPos = transform.position.x;
        else if(beingPushed == false && isCollPosionWater == true)
            transform.position = new Vector3(transform.position.x, transform.position.y);
    }
}
