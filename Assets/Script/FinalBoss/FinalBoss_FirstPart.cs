using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss_FirstPart : MonoBehaviour
{
    public static FinalBoss_FirstPart instance;

    private Animator anim;

    public GameObject[] lerpPosition;

    private Transform player;

    public bool facingLeft = true;
    [Header("LerpMove")]
    public float lerpSpeed;
    [SerializeField]private string positionPoint;

    [Header("MagicBall")]
    public bool isMagicBallAttack = false;
    public bool isMagicBallMove = false;
    [SerializeField]private Color color;
    [SerializeField]private SpriteRenderer spriteRenderer;

    [Header("FireBallRain")]
    public float LerpMiddleTopMoveSpeed;
    public GameObject fireBallMagicCircle;
    public GameObject fireDust;
    public static bool isFireBallrain = false;
    public GameObject fireBallBase;


    public AudioSetting audioSetting;

    private void Awake()
    {
        instance = this;
        audioSetting = GameObject.Find("SFX").GetComponent<AudioSetting>();
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<NewPlayerController>().transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    void RandomPick()
    {
        int randomState = Random.Range(0, 4);
        if (randomState != 3)
            anim.SetTrigger("Moving");
        else if (randomState == 3)
            anim.SetTrigger("MovingTop");

    }

    void RandomPickMagicBallAttack()
    {
        int randomState = Random.Range(0, 2);
        if (randomState == 0)
            anim.SetTrigger("MagicBallFire");
        else if (randomState == 1)
            anim.SetTrigger("MagicBallLerpMove");
    }

    public void MagicBall()
    {
        MagicBallObjectpool.instance.GetFromPool();
        audioSetting.soundEffectAudio[15].mute = false;
        audioSetting.soundEffectAudio[15].Play();
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
            if(positionPoint == "TopLeft")
            {
                transform.position = Vector2.Lerp(transform.position, lerpPosition[1].transform.position, lerpSpeed * Time.deltaTime);
                float MoveDirection = lerpPosition[1].transform.position.x - transform.position.x;
                FlipLerpMove(MoveDirection);
            }
            if(positionPoint == "TopRight")
            {
                transform.position = Vector2.Lerp(transform.position, lerpPosition[0].transform.position, lerpSpeed * Time.deltaTime);
                float MoveDirection = lerpPosition[0].transform.position.x - transform.position.x;
                FlipLerpMove(MoveDirection);
            }
            if(positionPoint == "BottomLeft")
            {
                transform.position = Vector2.Lerp(transform.position, lerpPosition[1].transform.position, lerpSpeed * Time.deltaTime);
                float MoveDirection = lerpPosition[1].transform.position.x - transform.position.x;
                FlipLerpMove(MoveDirection);
            }
            if(positionPoint == "BottomRight")
            {
                transform.position = Vector2.Lerp(transform.position, lerpPosition[0].transform.position, lerpSpeed * Time.deltaTime);
                float MoveDirection = lerpPosition[0].transform.position.x - transform.position.x;
                FlipLerpMove(MoveDirection);
            }
        }
    }

    public void LerpMagicBallMoveColor()
    {
        color = new Color(1, 1, 1, 1);
        spriteRenderer.color = color;
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
        int fireBallNum = Random.Range(2, 4);

        for (int i = 0; i < fireBallNum; i++)
        {
            float x = Random.Range(-83f, -36f);
            FireBallBaseObjectpool.instance.FireBallBaseGetFromPool(new Vector3(x, -10f));
        }
    }

    public void InjuryHurt()
    {
        StartCoroutine(ChangeColor(new Color(1f, 0.39f, 0.37f), 0.1f));
    }

    IEnumerator ChangeColor(Color color, float colorChangeTime)
    {
        spriteRenderer.color = color;
        yield return new WaitForSeconds(colorChangeTime);
        spriteRenderer.color = new Color(1, 1, 1);
    }

    public void FireBallMagicCircleOn()
    {
        //MagicCircle Create Audio
        audioSetting.soundEffectAudio[17].Play();
        audioSetting.soundEffectAudio[17].mute = false;
        fireBallMagicCircle.SetActive(true);
    }

    public void FireBallMagicCircleOff()
    {
        //MagicCircle Create Audio mute
        audioSetting.soundEffectAudio[17].mute = true;
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

    void AudioMute15()
    {
        audioSetting.soundEffectAudio[15].mute = true;
    }
}
