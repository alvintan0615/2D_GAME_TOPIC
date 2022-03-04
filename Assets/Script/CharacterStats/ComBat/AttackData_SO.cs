using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Attack" , menuName = "Character Stats/Attack Data")]
public class AttackData_SO : ScriptableObject
{
    [Header("Ｎormal Monster")]
    //Ｎormal　Monster
    public float coolDown;
    public float coolDown01;
    public int minDamage;
    public int maxDamage;
    public float attackRange;
    public float skillRange;
    public float criticalMultiplier;
    public float critcalChance;

    [Header("Tori")]
    //Tori
    public int windAttack;
    public int diveAttack;
    public int fireAttack;
}
