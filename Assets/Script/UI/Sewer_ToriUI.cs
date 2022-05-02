using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sewer_ToriUI : MonoBehaviour
{
    [SerializeField]Image healthSlider;
    [SerializeField]GameObject healthBar;
    public CharacterStats Sewer_Tori;
    void Awake()
    {
        healthBar = transform.GetChild(0).gameObject;
        healthSlider = transform.GetChild(0).GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        ToriUpdateBloodBar();
    }

    void ToriUpdateBloodBar()
    {
        if(EventManager.Instance.Sewer_TimeLineBossTori == true && EventManager.Instance.Tori_SewerHPBarClose == false)
        {
            healthBar.SetActive(true);
            float healthSliderPercent = (float)Sewer_Tori.CurrentHealth / Sewer_Tori.MaxHealth;
            healthSlider.fillAmount = healthSliderPercent;
        }
        else
            healthBar.SetActive(false);
    }
}
