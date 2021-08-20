using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateChanger
{
    public void ChangeState(IBehaviorState state);
}
