using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneWayPlatforms : MonoBehaviour
{
    public static PlayerOneWayPlatforms instance;

    public GameObject currentOneWayPlatform;

    [SerializeField] private BoxCollider2D playerCollider;

    public bool isOnLadder;

    private float YInput;
    private void Awake()
    {
        instance = this;
        playerCollider = this.gameObject.GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        YInput = Input.GetAxisRaw("Vertical");
        if (currentOneWayPlatform != null)
        {
            if (YInput < 0f && Input.GetButtonDown("Jump") && PlayerStatus.isClimbing == false)
            {
                PlayerStatus.isJumping = false;
                StartCoroutine(DisableCollision());
            }

            if (YInput < 0f && PlayerStatus.isClimbing == true)
            {
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
