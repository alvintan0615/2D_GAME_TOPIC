using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Data", menuName ="Character Stats/Data")]

public class CharacterData_SO : ScriptableObject
{
    [Header("Stats Info")]
    public int maxHealth;
    public int currentHealth;
    public int baseDefence;
    public int currentDefence;
    public int maxMana;
    public int currentMana;
    public int maxStamina;
    public int currentStamina;
    public int maxErosion;
    public int currentErosion;
}
