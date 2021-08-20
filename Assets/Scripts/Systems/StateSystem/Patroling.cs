using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroling : State, IStateStop
{
    private IBehaviorState deathState;
    private IBehaviorState aggresiveState;
    [SerializeField] private MovementSystem movementSys;
    [SerializeField] private float randomDelay = 3;
    [SerializeField] private float idleDelay = 10;
    
    protected override void Init()
    {
        deathState = transform.GetComponent<Death>();
        aggresiveState = transform.GetComponent<Aggresive>();
        movementSys = transform.GetComponent<MovementSystem>();
        print(this);
    }
    private IEnumerator Patrol()
    {
        movementSys.MoveTo(GetPositionToMove());
        yield return new WaitForSeconds(idleDelay + Random.Range(1,5));
        movementSys.MoveTo(GetPositionToMove());
        StopCoroutine("Patrol");
        StartCoroutine("Patrol");
    }
    private Vector3 GetPositionToMove()
    {
        Vector3 point = new Vector3(Random.Range(spawnPoint.x - randomDelay, spawnPoint.x + randomDelay), spawnPoint.y, Random.Range(spawnPoint.z - randomDelay, spawnPoint.z + randomDelay));
        return point;
    }

    public override void StateHandle()
    {
        StartCoroutine("Patrol");
    }

    public void StateStop()
    {
        StopAllCoroutines();
    }
}
