using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinalBossUI : MonoBehaviour
{
    [Header("FinalBossP1")]
    [SerializeField] Image healthSliderP1;
    [SerializeField] GameObject healthBarP1;
    public CharacterStats finalBossP1;
    [Header("FinalBossP2")]
    [SerializeField] Image healthSliderP2;
    [SerializeField] GameObject healthBarP2;
    public CharacterStats finalBossP2;
    void Awake()
    {
        healthBarP1 = transform.GetChild(0).gameObject;
        healthSliderP1 = transform.GetChild(0).GetChild(0).GetComponent<Image>();

        healthBarP2 = transform.GetChild(1).gameObject;
        healthSliderP2 = transform.GetChild(1).GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        FinalBossP1UpdateBloodBar();
        FinalBossP2UpdateBloodBar();
    }

    void FinalBossP1UpdateBloodBar()
    {
        if (EventManager.Instance.finalBossStart == true && EventManager.Instance.isFinalBossLetPlayerDead == false && EventManager.Instance.isFirstPartBossDead == false)
        {
            healthBarP1.SetActive(true);
            float healthSliderPercent = (float)finalBossP1.CurrentHealth / finalBossP1.MaxHealth;
            healthSliderP1.fillAmount = healthSliderPercent;
        }
        else
            healthBarP1.SetActive(false);
    }

    void FinalBossP2UpdateBloodBar()
    {
        if (EventManager.Instance.finalBossMiddle == true && EventManager.Instance.isFirstPartBossDead == true && EventManager.Instance.isFinalBossLetPlayerDead == false)
        {
            healthBarP2.SetActive(true);
            float healthSliderPercent = (float)finalBossP2.CurrentHealth / finalBossP2.MaxHealth;
            healthSliderP2.fillAmount = healthSliderPercent;
        }
        else
            healthBarP2.SetActive(false);
    }
}
