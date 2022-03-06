using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public CharacterData_SO templateData;

    public CharacterData_SO characterData;

    public AttackData_SO attackData;

    //public AttackData_SO templatAttackData;

    [HideInInspector]
    public bool isCritical;


    void Awake()
    {
        if(templateData != null)
        {
            characterData = Instantiate(templateData);
        }

        /*if(templatAttackData != null)
        {
            attackData = Instantiate(templatAttackData);
        }*/
    }

    #region Read from Data_SO
    public int MaxHealth
    {
        get
        {
            if (characterData != null)
                return characterData.maxHealth;
            else return 0;
        }
        set
        {
            characterData.maxHealth = value;
        }
    }
    public int CurrentHealth
    {
        get
        {
            if (characterData != null)
                return characterData.currentHealth;
            else return 0;
        }
        set
        {
            characterData.currentHealth = value;
        }
    }
    public int BaseDefence
    {
        get
        {
            if (characterData != null)
                return characterData.baseDefence;
            else return 0;
        }
        set
        {
            characterData.baseDefence = value;
        }
    }
    public int CurrentDefence
    {
        get
        {
            if (characterData != null)
                return characterData.currentDefence;
            else return 0;
        }
        set
        {
            characterData.currentDefence = value;
        }
    }

    public int MaxMana
    {
        get
        {
            if (characterData != null)
                return characterData.maxMana;
            else return 0;
        }
        set
        {
            characterData.maxMana = value;
        }
    }

    public int CurrentMana
    {
        get
        {
            if (characterData != null)
                return characterData.currentMana;
            else return 0;
        }
        set
        {
            characterData.currentMana = value;
        }
    }

    public int MaxStamina
    {
        get
        {
            if (characterData != null)
                return characterData.maxStamina;
            else return 0;
        }
        set
        {
            characterData.maxStamina = value;
        }
    }

    public int CurrentStamina
    {
        get
        {
            if (characterData != null)
                return characterData.currentStamina;
            else return 0;
        }
        set
        {
            characterData.currentStamina = value;
        }
    }

    public int MaxErosion
    {
        get
        {
            if (characterData != null)
                return characterData.maxErosion;
            else return 0;
        }
        set
        {
            characterData.maxErosion = value;
        }
    }

    public int CurrentErosion
    {
        get
        {
            if (characterData != null)
                return characterData.currentErosion;
            else return 0;
        }
        set
        {
            characterData.currentErosion = value;
        }
    }
    #endregion

    #region Character Combat

    public void TakeDamage(CharacterStats attacker, CharacterStats defener , int attackSkillValue)
    {
        int damage = Mathf.Max((attacker.CurrentDamage() + attackSkillValue) - defener.CurrentDefence, 0);
        CurrentHealth = Mathf.Max(CurrentHealth - damage, 0);

        if(defener.tag == "Player" && GameManager.Instance.Ken_Human == true && defener.characterData.currentHealth > 0)
        {
            Human_Skill.instance.Hurt();
            
            defener.GetComponent<TimeStop>().StopTime(0.05f, 10, 0.1f);
            //Rigidbody2D rb = defener.GetComponent<Rigidbody2D>();
            if (attacker.transform.position.x > defener.transform.position.x)
                StartCoroutine(GameManager.Instance.KnockBack(0.1f, -1700, 10, defener.transform.position, defener.GetComponent<Rigidbody2D>()));
            else if (attacker.transform.position.x < defener.transform.position.x)
                StartCoroutine(GameManager.Instance.KnockBack(0.1f, 1700, 10, defener.transform.position, defener.GetComponent<Rigidbody2D>()));
        }

        if(defener.tag == "Enemy" && defener.characterData.currentHealth > 0)
        {
            defener.GetComponent<Animator>().SetTrigger("Hurt");
            if (attacker.transform.position.x > defener.transform.position.x)
                StartCoroutine(GameManager.Instance.KnockBack(0.02f, -2000, 30, defener.transform.position, defener.GetComponent<Rigidbody2D>()));
            else if (attacker.transform.position.x < defener.transform.position.x)
                StartCoroutine(GameManager.Instance.KnockBack(0.02f, 2000, 30, defener.transform.position, defener.GetComponent<Rigidbody2D>()));
        }

        if(defener.tag == "Tori")
        {
            defener.GetComponent<Boss_Tori>().Injury();
        }
    }

    public void ThronDamage(int Damage, CharacterStats defender)
    {
        int damage = Mathf.Max(Damage - defender.CurrentDefence, 0);
        CurrentHealth = Mathf.Max(CurrentHealth - damage, 0);
    }

    public void TrapDamage(int minDamage, int maxDamage)
    {
        
        int trapDamage = UnityEngine.Random.Range(minDamage, maxDamage);
        CurrentHealth = Mathf.Max(CurrentHealth - trapDamage, 0);
    }

    private int CurrentDamage()
    {
        float coreDamage = UnityEngine.Random.Range(attackData.minDamage, attackData.maxDamage);
        return (int)coreDamage;

    }
    #endregion

    private void Update()
    {
        //Debug.Log("HP:"+CurrentHealth);
    }
}
