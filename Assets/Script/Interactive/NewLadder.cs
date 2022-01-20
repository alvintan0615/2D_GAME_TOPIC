using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLadder : MonoBehaviour
{


    private void OnTriggerStay2D(Collider2D collision)
    {
        float YInput = Input.GetAxisRaw("Vertical");
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if (collision.gameObject.tag == "Player" && YInput != 0f && GameManager.Instance.Ken_Human == true)
        {
            PlayerStatus.isClimbing = true;
        }
        if (PlayerStatus.isClimbing == true)
            collision.transform.position = new Vector2(this.transform.position.x, rb.position.y);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && GameManager.Instance.Ken_Human == true)
        {
            PlayerStatus.isClimbing = false;
        }
    }
}
