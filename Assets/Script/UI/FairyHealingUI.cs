using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyHealingUI : MonoBehaviour
{
    public GameObject healingUI1;
    public GameObject healingUI2;
    public GameObject healingUI3;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(GameManager.Instance.playerStats != null)
        {
            if (GameManager.Instance.playerStats.characterData.currentHealingTime == 0)
            {
                healingUI1.SetActive(false);
                healingUI2.SetActive(false);
                healingUI3.SetActive(false);
            }else if(GameManager.Instance.playerStats.characterData.currentHealingTime == 1)
            {
                healingUI1.SetActive(true);
                healingUI2.SetActive(false);
                healingUI3.SetActive(false);
            }else if(GameManager.Instance.playerStats.characterData.currentHealingTime == 2)
            {
                healingUI1.SetActive(true);
                healingUI2.SetActive(true);
                healingUI3.SetActive(false);
            }else if(GameManager.Instance.playerStats.characterData.currentHealingTime == 3)
            {
                healingUI1.SetActive(true);
                healingUI2.SetActive(true);
                healingUI3.SetActive(true);
            }
                
        }
    }
}
