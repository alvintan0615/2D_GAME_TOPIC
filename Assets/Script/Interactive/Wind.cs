using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Wind : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Boss_Tori tori;
    [SerializeField] Vector2 windDir;
    private Rigidbody2D rb;
    private int randomX;
    private float naturalGravity;
    [Header("PhysicsCheck")]
    [SerializeField] Transform groundCheckDown;
    [SerializeField] Transform groundCheckUp;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundlayer;
    private bool isTouchingUp;
    private bool isTouchingDown;
    private bool goingUp = false;

    private void OnEnable()
    {
        randomX = Random.Range(1, 10);
        tori = GameObject.FindGameObjectWithTag("Tori").GetComponent<Boss_Tori>();
        rb = GetComponent<Rigidbody2D>();
        naturalGravity = rb.gravityScale;
        if (tori.facingLeft == true)
            windDir.x *= -1;
        else
            windDir.x *= 1;
    }
    void Start()
    {
        
    }

    void Update()
    {
        physicsCheck();

        StartCoroutine(WindAttack());
        //WindAttack();
        
    }

    /*void WindAttack()
    {
        if (isTouchingUp && goingUp)
            ChangeDirection();
        else if (isTouchingDown && !goingUp)
            ChangeDirection();
        
        rb.velocity = new Vector2(speed * windDir.x * randomX, windDir.y * randomX);
            
        Destroy(gameObject, 10);
    }*/

    void ChangeDirection()
    {
        goingUp = !goingUp;
        windDir.y *= -1;
    }

    IEnumerator WindAttack()
    {
        rb.gravityScale = 0f;
        if (isTouchingUp && goingUp)
            ChangeDirection();
        else if (isTouchingDown && !goingUp)
            ChangeDirection();
        
        yield return new WaitForSeconds(1);
        rb.gravityScale = naturalGravity;
        rb.velocity = new Vector2(speed * windDir.x * randomX, windDir.y * randomX);

        Destroy(gameObject, 10);
    }


    void physicsCheck()
    {
        isTouchingUp = Physics2D.OverlapCircle(groundCheckUp.position, groundCheckRadius, groundlayer);
        isTouchingDown = Physics2D.OverlapCircle(groundCheckDown.position, groundCheckRadius, groundlayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheckUp.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckDown.position, groundCheckRadius);
    }
}
