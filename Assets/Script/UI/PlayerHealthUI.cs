using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthUI : MonoBehaviour
{
    Image healthSlider;

    Image ManaSlider;

    Image staminaSlider;

    /*Image erosionSlider;*/

    void Awake()
    {
        healthSlider = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        /*erosionSlider = transform.GetChild(1).GetChild(0).GetComponent<Image>();*/
    }

    void Update()
    {
        UpdateHealth();
        /*UpdateErosion();*/
        
    }

    void UpdateHealth()
    {
        float healthSliderPercent = (float)GameManager.Instance.playerStats.CurrentHealth / GameManager.Instance.playerStats.MaxHealth;
        healthSlider.fillAmount = healthSliderPercent;
    }

    /*void UpdateErosion()
    {
        float erosionSliderPercent = (float)GameManager.Instance.playerStats.CurrentErosion / GameManager.Instance.playerStats.MaxErosion;
        erosionSlider.fillAmount = erosionSliderPercent;
        
    }*/
}
