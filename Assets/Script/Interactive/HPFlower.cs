using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPFlower : MonoBehaviour
{
    private Color color;
    private SpriteRenderer spriteRenderer;
    public float alpha;
    public float alphaMutipulier;
    public bool isSlowDestory;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
           if(isSlowDestory == true)
        {
            SlowDestory();
        } 
    }

    public void SlowDestory()
    {
        alpha *= alphaMutipulier;
        color = new Color(1, 1, 1, alpha);
        spriteRenderer.color = color;
        if (alpha < 0.1f)
            Destroy(gameObject);
    }
}
