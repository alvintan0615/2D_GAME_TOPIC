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
    int magicBallCount;
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

    void FlipTowardsPlayer()
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
