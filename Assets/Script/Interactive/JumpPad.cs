using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public Animator anim;
    public Animator anim2;
    public float x;
    [SerializeField] private float bounce = 20f; 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("JumpPad");
            anim2.SetTrigger("JumpPad");
            NewPlayerController.instance.cantJumpMove = true;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(x,1) * bounce, ForceMode2D.Impulse);
        }
    }
}
