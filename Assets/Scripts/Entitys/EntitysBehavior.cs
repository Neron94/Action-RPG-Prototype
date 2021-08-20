using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitysBehavior : MonoBehaviour, IStateChanger
{
    [SerializeField] private string curStateName;
    private IBehaviorState curState;
    private IStateStop stopCurState;
    private void Start()
    {
        ChangeState(transform.GetComponent<Patroling>());
    }


    public void ChangeState(IBehaviorState state)
    {
        if (curState != null) stopCurState.StateStop();
        curState = state;
        curStateName = state.ToString();
        state.StateHandle();
        stopCurState = (IStateStop)state;
    }

    public void OnTriggerEnter(Collider other)
    {
        Aggresive agrState = transform.GetComponent<Aggresive>();
        ChangeState(agrState);
        agrState.IntruderObject = other.gameObject;
    }

    //ме гюашрэ --опн бйкчвемхъ юцпеяях еякх лнаю юрюйнбюкх-- (днярхл ксйнл с йнрнпнцн дхярюмя анкэье йнккюидепю юцпеяхх)
}
