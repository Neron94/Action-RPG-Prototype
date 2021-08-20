using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : State, IStateStop
{
    private IBehaviorState patrolingState;
    private IBehaviorState aggresiveState;

    protected override void Init()
    {
        patrolingState = transform.GetComponent<Patroling>();
        aggresiveState = transform.GetComponent<Aggresive>();
    }

    public override void StateHandle()
    {
        print(gameObject.name + "is Dead");
        //анимация смерти
        gameObject.SetActive(false);
    }

    public void StateStop()
    {
        gameObject.SetActive(true);
        //включаем стейт патруля ручным образом
    }
}
