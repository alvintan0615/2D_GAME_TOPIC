using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    PlayerController Controller;
    void Start()
    {
        anim = GetComponent<Animator>();
        Controller = GetComponentInParent<PlayerController>();
    }

    void Update()
    {
        
    }
}
