using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelSystemToUi
{
    public int GetLevel();
    public int GetExp();
    public int GetExpToNextLevel();
}
