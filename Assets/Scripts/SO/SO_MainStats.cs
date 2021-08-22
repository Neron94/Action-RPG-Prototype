using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityStats", menuName = "Stats/Main Stats", order = 1)]
public class SO_MainStats : SO_EntityStats
{
    [SerializeField] private float baseDamage, baseAttackSpeed;
    [SerializeField] private float baseDodge, baseDefence;
    [SerializeField] private float maxHp, curHp;
    [SerializeField] private float baseCarrying;
    [SerializeField] private float hpRecovery;

    [Header("Сила")]
    [SerializeField] private int power;
    [Header("Ловкость")]
    [SerializeField] private int agility;
    [Header("Живучесть")]
    [SerializeField] private int vitality;

    public float BaseDamageChange
    {
        get
        {
            return baseDamage;
        }
        set
        {
            baseDamage = value;
        }
    }
    public float BaseAttackSpeedChange
    {
        get
        {
            return baseAttackSpeed;
        }
        set
        {
            baseAttackSpeed = value;
        }
    }
    public float BaseDodgeChange
    {
        get
        {
            return baseDodge;
        }
        set
        {
            baseDodge = value;
        }
    }
    public float BaseDefenceChange
    {
        get
        {
            return baseDefence;
        }
        set
        {
            baseDefence = value;
        }
    }
    public float MaxHpChange
    {
        get
        {
            return maxHp;
        }
        set
        {
            maxHp = value;
        }
    }
    public float CurHpChange
    {
        get
        {
            return curHp;
        }
        set
        {
            curHp = value;
        }
    }
    public float BaseCarryingChange
    {
        get
        {
            return baseCarrying;
        }
        set
        {
            baseCarrying = value;
        }
    }
    public float HpRecoveryChange
    {
        get
        {
            return hpRecovery;
        }
        set
        {
            hpRecovery = value;
        }
    }
    public int PowerChange
    {
        get
        {
            return power;
        }
        set
        {
            power = value;
        }
    }
    public int AgilityChange
    {
        get
        {
            return agility;
        }
        set
        {
            agility = value;
        }
    }
    public int VitalityChange
    {
        get
        {
            return vitality;
        }
        set
        {
            vitality = value;
        }
    }
}


