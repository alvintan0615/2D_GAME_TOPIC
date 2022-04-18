using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed;
    public static bool isFollowPlayer = false;
    [SerializeField] Transform target;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("FairyPosition").GetComponent<Transform>();
    }
    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (target != null)
        {
            isFollowPlayer = true;
            if (NewPlayerController.instance.facingRight == true)
                spriteRenderer.flipX = false;
            else
                spriteRenderer.flipX = true;

            transform.position = Vector2.Lerp(transform.position, target.position, speed * Time.deltaTime);
        }
        else
            isFollowPlayer = false;
        
    }
}
