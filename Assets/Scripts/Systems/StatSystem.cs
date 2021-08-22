using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSystem : MySystem, IStatToUi
{
    [SerializeField] private SO_MainStats playerStats;
    [SerializeField] private int skillPoints;
    [SerializeField] private int skillPointsOnLevel;
    [SerializeField] private float baseStatsValue = 5f;
    [SerializeField] private int baseSkillsAddToStats = 10;

    private void AddBaseStatsOnLevel()
    {
        baseStatsValue = 10f * transform.GetComponent<LevelSystem>().GetLevel();
        playerStats.MaxHpChange += baseStatsValue;
        playerStats.BaseDamageChange += baseStatsValue;
        playerStats.BaseAttackSpeedChange += baseStatsValue;
    }

    public void AddPointsOnSkills(string type)
    {
        if(skillPoints >0)
        {
            switch (type)
            {
                case "Power":
                    playerStats.PowerChange++;
                    playerStats.BaseDamageChange += baseSkillsAddToStats;
                    playerStats.BaseCarryingChange += baseSkillsAddToStats;
                    skillPoints--;
                    break;
                case "Agility":
                    playerStats.AgilityChange++;
                    playerStats.BaseAttackSpeedChange += baseSkillsAddToStats;
                    playerStats.BaseDodgeChange += baseSkillsAddToStats;
                    skillPoints--;
                    break;
                case "Vitality":
                    playerStats.VitalityChange++;
                    playerStats.HpRecoveryChange += baseSkillsAddToStats;
                    playerStats.MaxHpChange += baseSkillsAddToStats;
                    skillPoints--;
                    break;
            }
        }
    }
    public void LevelUp()
    {
        AddBaseStatsOnLevel();
        skillPoints += skillPointsOnLevel;
    }
    public SO_MainStats GetStats() { return playerStats; }
}
