using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour, IBehaviorState
{
    private IStateChanger entityState;
    protected Vector3 spawnPoint;

    protected virtual void Init()
    {
        Debug.Log("Method has not ovverrided");
    }

    public void Awake()
    {
        entityState = transform.GetComponent<IStateChanger>();
        spawnPoint = transform.position;
        Init();
    }

    public virtual void StateHandle()
    {
        Debug.Log("Method has not ovverrided");
    }

}
