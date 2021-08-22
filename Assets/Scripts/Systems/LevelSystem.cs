using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MySystem, ILevelSystemToUi
{
    [SerializeField] private int[] expGrid = new int[10];
    [SerializeField] private int curLevel;
    [SerializeField] private int expirienceCount;
    [SerializeField] private StatSystem statSystem;

    private void Awake()
    {
        statSystem = transform.GetComponent<StatSystem>();
    }
    private void LevelUp()
    {
        curLevel++;
        statSystem.LevelUp();
    }
    
    public void AddExperience(int count)
    {
        expirienceCount += count;
        if(expirienceCount>=expGrid[curLevel])
        {
            LevelUp();
        }
    }
    public int GetLevel()
    {
        return curLevel;
    }
    public int GetExp()
    {
        return expirienceCount;
    }
    public int GetExpToNextLevel()
    {
        return expGrid[curLevel+1];
    }
    

}
