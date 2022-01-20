using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSignal()
    {
        GameManager.Instance.Ken_Human = false;
        EventManager.Instance.canChange = true;
        GameManager.Instance.playerStats.characterData.currentHealth = 100;
        GameManager.Instance.playerStats.characterData.currentDefence += 5;
        GameManager.Instance.playerStats.attackData.minDamage += 5;
        GameManager.Instance.playerStats.attackData.maxDamage += 5;
        NewPlayerController.instance.anim.Play("Change_Demon");
        
    }

    public void ChangeToriAnim()
    {
        Boss_Tori.instance.anim.Play("FlyIdle");
    }

    public void ManagerHumanTrue()
    {
        GameManager.Instance.Ken_Human = true;
        NewPlayerController.instance.anim.Play("Change_Human");
    }
}
