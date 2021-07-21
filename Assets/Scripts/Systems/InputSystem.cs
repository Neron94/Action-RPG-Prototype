using UnityEngine;


public class InputSystem : MySystem
{
    //Система оперирует вводными данными игрока

    [SerializeField] MovementSystem movementSys;
    [SerializeField] InteractionSystem interactionSystem;

    private void Update()
    {
        if (Input.GetMouseButton(1)) SendPosToMove();
        if (Input.GetMouseButtonUp(0))
        {
            if (!interactionSystem.IsHaveObjectOnRay())
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
