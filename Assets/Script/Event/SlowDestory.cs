using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDestory : MonoBehaviour
{
    private Color color;
    private SpriteRenderer spriteRenderer;
    public GameObject button;
    public float alpha;
    public float alphaMutipulier;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(EventManager.Instance.takeFood == true)
        {
            button.SetActive(false);
            alpha *= alphaMutipulier;
            color = new Color(1, 1, 1, alpha);
            spriteRenderer.color = color;
            if (alpha < 0.1f)
                Destroy(gameObject);
        }
    }
}
