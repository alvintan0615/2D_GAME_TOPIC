using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    private Color color;
    private Color color2;
    private SpriteRenderer spriteRenderer;
    public float alpha;
    public float negativeAlphaMutipulier;
    public float positiveAlphaMutipulier;
    public bool isOutside;
    void Awake()
    {
        spriteRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
        isOutside = true;
    }

    void Update()
    {
        if(isOutside != false)
        {
            alphaPlus();
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == ("Player"))
        {
            isOutside = false;
            alphaMinus();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            isOutside = true;
        }
        
    }

    void alphaMinus()
    {
        alpha *= negativeAlphaMutipulier;
        color = new Color(1, 1, 1, alpha);
        spriteRenderer.color = color;
        if (alpha < 0.1f)
            alpha = 0.01f;
    }

    void alphaPlus()
    {
        alpha *= positiveAlphaMutipulier;
        color2 = new Color(1, 1, 1, alpha);
        spriteRenderer.color = color2;
        if (alpha > 0.9f)
            alpha = 1f;
    }
}
