using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneWayPlatforms : MonoBehaviour
{
    private GameObject currentOneWayPlatform;

    [SerializeField] private BoxCollider2D playerCollider;


    private void Awake()
    {
        playerCollider = this.gameObject.GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        
        
            if(currentOneWayPlatform != null)
            {
                if (Input.GetKey(KeyCode.DownArrow) && Input.GetButtonDown("Jump"))
                {
                    PlayerStatus.isJumping = false;
                    StartCoroutine(DisableCollision());
                }
                    
            }
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatForm"))
        {
            currentOneWayPlatform = collision.gameObject;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatForm"))
        {
            currentOneWayPlatform = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        
        Collider2D platformCollider = currentOneWayPlatform.GetComponent<Collider2D>();
        
        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(1f);
        PlayerStatus.isJumping = true;
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }

}
