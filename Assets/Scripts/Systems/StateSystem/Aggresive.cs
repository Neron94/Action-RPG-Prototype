using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aggresive : State,IStateStop
{
    private IBehaviorState patrolingState;
    private IBehaviorState deathState;
    private IStateChanger changeState;
    [SerializeField] private MovementSystem movementSys;
    [SerializeField] private GameObject intruderObject;
    [SerializeField] private float pursuitDistance = 15;
    [SerializeField] private float distToAttack = 0.8f;
    [SerializeField] private bool isStateActive = false;

    protected override void Init()
    {
        deathState = transform.GetComponent<Death>();
        patrolingState = transform.GetComponent<Patroling>();
        movementSys = transform.GetComponent<MovementSystem>();
        changeState = transform.GetComponent<EntitysBehavior>();
    }
    private float DistanceBetween(Vector3 position)
    {
        float dist = Vector3.Distance(position, intruderObject.transform.position);
        return dist;
    }
    private void Update()
    {
        if(isStateActive)
        {
            if (DistanceBetween(spawnPoint) > pursuitDistance)
            {
                changeState.ChangeState(transform.GetComponent<Patroling>());
            }
            else
            {
                if (DistanceBetween(transform.position) > distToAttack)
                {
                    movementSys.MoveTo(intruderObject.transform.position);
                }
                else
                {
                    movementSys.MoveTo(transform.position); // заплаточка для остановки моба на дистанции атаки от цели
                    // ТУТ КОД АТАКИ!
                    // ПРОВЕРЯЕМ УМЕР ЛИ!? ЕСЛИ ДА ТО ВОЗВРАЩАЕМСЯ К ПАТРУЛИРОВАНИЮ
                }
            }
        }
    }

    public GameObject IntruderObject
    {
        get
        {
            return intruderObject;
        }
        set
        {
            intruderObject = value;
        }
    }

    public override void StateHandle()
    {
        isStateActive = true;
    }

    public void StateStop()
    {
        isStateActive = false;
    }
}
