using UnityEngine;

//Система оперирует вводными данными игрока
public class InputSystem : MySystem
{
    [SerializeField] IMoveTo movementSys;
    [SerializeField] IInteractionRay interactionSys;

    private void Awake()
    {
        movementSys = gameObject.GetComponent<IMoveTo>();
        interactionSys = gameObject.GetComponent<IInteractionRay>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(1)) SendPosToMove();
        if (Input.GetMouseButtonUp(0))
        {
            if (!interactionSys.IsHaveObjectOnRay())
            { 
                SendPosToMove(); 
            }
        }
            
    }

    void SendPosToMove()
    {
        Vector3 positionToMove = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 12));
        movementSys.MoveTo(new Vector3(positionToMove.x, 0, positionToMove.z));
    }    
}
