using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsToUi : MonoBehaviour
{
    private ILevelSystemToUi levelSys;
    private IStatToUi statSys;

    [SerializeField] private Image hpBar;
    [SerializeField] private Text hpText;
    [SerializeField] private Image expBar;
    [SerializeField] private Text expText;
    [SerializeField] private Text curLevel;
    [SerializeField] private Image playerIcon;
    [SerializeField] private SO_MainStats playerStats;


    private void Awake()
    {
        levelSys = transform.GetComponent<ILevelSystemToUi>();
        statSys = transform.GetComponent<IStatToUi>();
        playerStats = statSys.GetStats();
    }
    private void LevelChange(int Level) { curLevel.text = Level.ToString()+" Level"; }

    public void HpChange()
    {
        int maxHp = (int)playerStats.MaxHpChange;
        int curHp = (int)playerStats.CurHpChange;
        hpBar.fillAmount = (float)curHp / maxHp;
        hpText.text = "HP:" + curHp + "/" + maxHp;
    }
    public void ExpChange()
    {
        int needExpToLevel = levelSys.GetExpToNextLevel();
        int curExp = levelSys.GetExp();
        expBar.fillAmount = (float)curExp / needExpToLevel;
        expText.text = "EXP:" + curExp + "/" + needExpToLevel;
        LevelChange(levelSys.GetLevel());
    }
    // Надо написать ивент на измененния ХП и Экспы

}
