using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryWood : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Attacktrigger")
        {
            anim.SetBool("isTrigger", true);
        }
    }
}
