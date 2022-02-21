using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed;
    [SerializeField] Transform target;
    [SerializeField] SpriteRenderer spriteRenderer;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("FairyPosition").GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(target != null)
        {
            if (NewPlayerController.instance.facingRight == true)
                spriteRenderer.flipX = false;
            else
                spriteRenderer.flipX = true;

            transform.position = Vector2.Lerp(transform.position, target.position, speed * Time.deltaTime);
        } 
        
    }
}
