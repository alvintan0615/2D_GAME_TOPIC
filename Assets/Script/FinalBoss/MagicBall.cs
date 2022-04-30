using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    public GameObject target;
    Vector3 targetPos;
    public GameObject player;
    public float distance;
    Vector3 dir;
    private bool isAttack = false;
    public float isAttackTime;
    public float isAroundTime;
    private bool hasPlayerPosition;
    private Vector3 playerPosition;
    public float ballSpeed;
    public float timer;
    private bool isStopAround = false;
    [SerializeField]private float recordTimer;
    float r;
    public int number;
    public AudioSetting audioSetting;
    private void Awake()
    {
        recordTimer = timer;
        audioSetting = GameObject.Find("SFX").GetComponent<AudioSetting>();
    }
    void OnEnable()
    {

        target = GameObject.FindGameObjectWithTag("FinalBoss_FirstPart");
        player = GameObject.FindGameObjectWithTag("Player");
        //int randomPick = Random.Range(5, 10);

        dir = transform.position - target.transform.position;
        targetPos = target.transform.position;
        isAttack = false;
        isStopAround = false;
        timer = recordTimer;
    }


    void Update()
    {
        if (EventManager.Instance.isFinalBossLetPlayerDead == true || EventManager.Instance.isFirstPartBossDead == true)
        {
            audioSetting.soundEffectAudio[15].mute = true;
            MagicBallObjectpool.instance.ReturnPool(this.gameObject);
        }
            

        var targetCharacterStats = target.GetComponent<CharacterStats>();
        if(targetCharacterStats.CurrentHealth <= 0)
        {
            MagicBallObjectpool.instance.ReturnPool(this.gameObject);
        }

        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = 0;
        }

        if(FinalBoss_FirstPart.instance.isMagicBallAttack == false && FinalBoss_FirstPart.instance.isMagicBallMove == false && isStopAround == false)
        {

            MagicBallAround();
        }
        

        if (FinalBoss_FirstPart.instance.isMagicBallAttack == true)
        {
            StartCoroutine(BoolMagicBallAttack(isAttackTime));
            if (timer == 0)
            {
                MagicBallAttack();
            }
                
            else
                MagicBallLerpMove();
        }

        if(FinalBoss_FirstPart.instance.isMagicBallMove == true)
        {
            
            StartCoroutine(BoolMagicBallLerpAround(isAroundTime));
            if(isAttack == true)
            {
                MagicBallAttack();
            }
                
            else
                MagicBallLerpMove();
        }
    }

    void MagicBallAround()
    {
            transform.position = target.transform.position + dir.normalized * distance;
            transform.RotateAround(target.transform.position, Vector3.forward, 90 * Time.deltaTime);
            dir = transform.position - target.transform.position;
    }

    void MagicBallLerpMove()
    {
        transform.position = target.transform.position + dir.normalized * distance;
        transform.RotateAround(target.transform.position, Vector3.forward, 90 * Time.deltaTime);
        dir = transform.position - target.transform.position;
    }

    void MagicBallAttack()
    {
        /*if(FinalBoss_FirstPart.isMagicBallMove == true)
        {
            StartCoroutine(BoolMagicBallLerpAround());
            transform.position = target.transform.position + dir.normalized * distance;
            transform.RotateAround(target.transform.position, Vector3.forward, 90 * Time.deltaTime);
            dir = transform.position - target.transform.position;
        }
        else
        {*/
        
        if (!hasPlayerPosition)
        {
            playerPosition = player.transform.position - transform.position;
            playerPosition.Normalize();
            hasPlayerPosition = true;
        }
        if (hasPlayerPosition)
        {
            transform.position += playerPosition * ballSpeed;
        }

        /*}*/

    }


    IEnumerator BoolMagicBallAttack(float isAttackTime)
    {
        isStopAround = true;
        yield return new WaitForSeconds(isAttackTime);
        hasPlayerPosition = false;
        MagicBallObjectpool.instance.ReturnPool(this.gameObject);
    }

    IEnumerator BoolMagicBallLerpAround(float isAroundTime)
    {
        isStopAround = true;
        yield return new WaitForSeconds(2f);
        isAttack = true;

        yield return new WaitForSeconds(isAroundTime);
        hasPlayerPosition = false;
        MagicBallObjectpool.instance.ReturnPool(this.gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            var bossStats = target.GetComponent<CharacterStats>();
            var playerStats = player.GetComponent<CharacterStats>();
            playerStats.TakeDamage(bossStats, playerStats, 5);
        }
    }
}
