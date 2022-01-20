using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSprite : MonoBehaviour
{
    private Transform player;

    private SpriteRenderer thisSprite;
    private SpriteRenderer playerSprite;

    private Color color;

    [Header("時間參數")]
    public float ativeTime;
    public float activeStart;


    [Header("不透明度參數")]
    public float alpha;
    public float alphaSet;
    public float alphaMultiplier;

    void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        thisSprite = GetComponent<SpriteRenderer>();
        playerSprite = player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;

        thisSprite.sprite = playerSprite.sprite;

        transform.position = player.position;
        transform.localScale = player.localScale;
        transform.rotation = player.rotation;

        activeStart = Time.time;
    }

    void Update()
    {
        alpha *= alphaMultiplier;

        color = new Color(0.5f, 0.5f, 1, alpha);

        thisSprite.color = color;

        ShadowPool.Instance.ReturnPool(this.gameObject);
    }
}
