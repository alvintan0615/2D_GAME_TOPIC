using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Demon_Skill : MonoBehaviour
{
    public static Demon_Skill instance;
    private Animator anim;

    [Header("普攻相關")]
    public bool isNormalAttack = false;

    [Header("技能相關")]
    public bool isBeamSkill = false;
    public bool isAllScreenSkill = false;
    [SerializeField] private SpriteRenderer effect;
    [SerializeField] private GameObject effectCanvas;

    [Header("技能冷卻")]
    private bool beamSkillIsOn = false;
    private float beamSkillTimer;
    public float beamSkillCD;
    private bool AllScreenSkillIsOn = false;
    private float AllScreenSkillTimer;
    public float AllScreenSkillCD;
    [SerializeField]private Image beamSkillFilledImage;
    [SerializeField]private Image allScreenSkillFilledImage;

    #region Animation State
    private string currentState;
    const string DEMON_NORMALATTACK1 = "Demon_NormalAttack1";
    const string DEMON_BEAMSKILL = "Demon_BeamSkill";
    const string DEMON_ALLSCREENSKILL = "Demon_AllScreenSkill";
    #endregion
    private void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
        effect = transform.GetChild(1).GetComponent<SpriteRenderer>();
        effectCanvas = transform.GetChild(2).gameObject;

        
    }
    private void OnEnable()
    {
        beamSkillFilledImage = GameObject.FindGameObjectWithTag("beamSkillFilledImage").GetComponent<Image>();
        allScreenSkillFilledImage = GameObject.FindGameObjectWithTag("allScreenSkillFilledImage").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isChanging", PlayerStatus.isChanging);
        anim.SetBool("isDead", NewPlayerController.instance.isDead);
        NormalAttack();
        BeamSkill();
        AllScreenSkill();
        DemonSkillIsOn();
        if (PlayerStatus.isChanging == false)
        {
            effect.sprite = null;
            effectCanvas.SetActive(false);
        }
        
    }

    void NormalAttack()
    {
        if (PlayerStatus.canAttack == false) return;

        if (PlayerStatus.canAttack == true && Input.GetButtonDown("Fire1"))
        {
            isNormalAttack = true;
            if (isNormalAttack == true)
            {
                PlayerStatus.isAttacking = true;
                //NewPlayerController.instance.DemonState(DEMON_NORMALATTACK1);
            }

        }
        //Debug.Log(isNormalAttack);
    }

    void BeamSkill()
    {
        if (PlayerStatus.canSkill == false) return;

        if (Input.GetButtonDown("Fire2") && PlayerStatus.canSkill == true && isAllScreenSkill == false && PlayerStatus.isHurting == false && beamSkillIsOn == false)
        {
            isBeamSkill = true;
            if (isBeamSkill == true)
            {
                PlayerStatus.isSkilling = true;
                NewPlayerController.instance.DemonState(DEMON_BEAMSKILL);
                beamSkillIsOn = true;
            }
            else
            {
                isBeamSkill = false;
                PlayerStatus.isSkilling = false;
            }
        }
    }

    void AllScreenSkill()
    {
        if (PlayerStatus.canSkill == false) return;

        if (Input.GetButtonDown("Fire3") && PlayerStatus.canSkill == true && isBeamSkill == false 
            && PlayerStatus.isHurting == false && AllScreenSkillIsOn == false && EventManager.Instance.canUseAllSceenSkill == true)
        {
            isAllScreenSkill = true;
            if (isAllScreenSkill == true)
            {
                PlayerStatus.isSkilling = true;
                NewPlayerController.instance.DemonState(DEMON_ALLSCREENSKILL);
                AllScreenSkillIsOn = true;
            }
            else
            {
                isAllScreenSkill = false;
                PlayerStatus.isSkilling = false;
            }
        }
    }

    void DemonSkillIsOn()
    {
        if (beamSkillIsOn == true)
        {
            beamSkillTimer += Time.deltaTime;
            beamSkillFilledImage.fillAmount = (beamSkillCD - beamSkillTimer) / beamSkillCD;
            if (beamSkillTimer >= beamSkillCD)
            {
                beamSkillFilledImage.fillAmount = 0;
                beamSkillIsOn = false;
                beamSkillTimer = 0f;
            }
        }

        if (AllScreenSkillIsOn == true)
        {
            AllScreenSkillTimer += Time.deltaTime;
            allScreenSkillFilledImage.fillAmount = (AllScreenSkillCD - AllScreenSkillTimer) / AllScreenSkillCD;
            if (AllScreenSkillTimer >= AllScreenSkillCD)
            {
                allScreenSkillFilledImage.fillAmount = 0;
                AllScreenSkillIsOn = false;
                AllScreenSkillTimer = 0f;
            }
        }
    }


    void DemonState(string newState)
    {
        if (currentState == newState || GameManager.Instance.Ken_Human == true) return;

        anim.Play(newState);

        currentState = newState;
    }
}
