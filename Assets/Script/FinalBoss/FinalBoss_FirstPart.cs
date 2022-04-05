using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss_FirstPart : MonoBehaviour
{
    private Animator anim;

    public GameObject[] lerpPosition;

    private Transform player;

    public bool facingLeft = true;
    [Header("LerpMove")]
    public float lerpSpeed;
    [SerializeField]private string positionPoint;

    [Header("MagicBall")]
    public static bool isMagicBallMove = false;
    private Color color;
    private SpriteRenderer spriteRenderer;

    [Header("FireBallRain")]
    public float LerpMiddleTopMoveSpeed;
    public GameObject fireBallMagicCircle;
    public GameObject fireDust;
    public static bool isFireBallrain = false;
    public GameObject fireBallBase;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<NewPlayerController>().transform;
    }

    void Update()
    {
        
    }

    public void MagicBall()
    {
        MagicBallObjectpool.instance.GetFromPool();
    }


    public void LerpMiddleTopMove()
    {
        if (player != null && PlayerStatus.isDialouging == false)
        {
            positionPoint = "MiddleTop";
            transform.position = Vector2.Lerp(transform.position, lerpPosition[4].transform.position, LerpMiddleTopMoveSpeed * Time.deltaTime);
            float MoveDirection = lerpPosition[0].transform.position.x - transform.position.x;
            FlipLerpMove(MoveDirection);
        }
    }

    public void LerpMagicBallMove()
    {
        if(isMagicBallMove == true)
        {
            color = new Color(1, 1, 1, 0);
            spriteRenderer.color = color;
        }
        else
        {
            color = new Color(1, 1, 1, 1);
            spriteRenderer.color = color;
        }
        
    }

    public void LerpMove(int randomState)
    {
        if (player != null && PlayerStatus.isDialouging == false)
        {
            if(randomState == 0)
            {
                positionPoint = "TopLeft";
                transform.position = Vector2.Lerp(transform.position, lerpPosition[0].transform.position, lerpSpeed * Time.deltaTime);
                float MoveDirection = lerpPosition[0].transform.position.x - transform.position.x;
                FlipLerpMove(MoveDirection);
            }
            if (randomState == 1)
            {
                positionPoint = "TopRight";
                transform.position = Vector2.Lerp(transform.position, lerpPosition[1].transform.position, lerpSpeed * Time.deltaTime);
                float MoveDirection = lerpPosition[1].transform.position.x - transform.position.x;
                FlipLerpMove(MoveDirection);
            }
            if (randomState == 2)
            {
                positionPoint = "BottomLeft";
                transform.position = Vector2.Lerp(transform.position, lerpPosition[2].transform.position, lerpSpeed * Time.deltaTime);
                float MoveDirection = lerpPosition[2].transform.position.x - transform.position.x;
                FlipLerpMove(MoveDirection);
            }
            if (randomState == 3)
            {
                positionPoint = "BottomRight";
                transform.position = Vector2.Lerp(transform.position, lerpPosition[3].transform.position, lerpSpeed * Time.deltaTime);
                float MoveDirection = lerpPosition[3].transform.position.x - transform.position.x;
                FlipLerpMove(MoveDirection);
            }
        }
    }

    void FlipLerpMove(float MoveDirection)
    {
        if (MoveDirection > 0 && facingLeft)
            flip();
        else if (MoveDirection < 0 && !facingLeft)
            flip();
    }

    public void FireBallBase()
    {
        int fireBallNum = Random.Range(1, 3);

        for (int i = 0; i < fireBallNum; i++)
        {
            float x = Random.Range(-76f, -40f);
            FireBallBaseObjectpool.instance.FireBallBaseGetFromPool(new Vector3(x, -10f));
        }
    }

    public void FireBallMagicCircleOn()
    {
        fireBallMagicCircle.SetActive(true);
    }

    public void FireBallMagicCircleOff()
    {
        fireBallMagicCircle.SetActive(false);
    }

    public void FireDustOn()
    {
        fireDust.SetActive(true);
    }

    public void FireDustOff()
    {
        fireDust.SetActive(false);
    }

    public void FlipTowardsPlayer()
    {
        float playerDirection = player.position.x - transform.position.x;

        if (playerDirection > 0 && facingLeft)
            flip();
        else if (playerDirection < 0 && !facingLeft)
            flip();
    }

    void flip()
    {
        facingLeft = !facingLeft;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}
