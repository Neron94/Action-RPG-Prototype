using UnityEngine;

//Система оперирует вводными данными игрока
public class InputSystem : MySystem, IOnUi
{
    [SerializeField] private IDialogueToUI movementSys;
    [SerializeField] private IInteractionRay interactionSys;
    [SerializeField] private bool isOnUI = false;
    [SerializeField] private GameObject player;

    private void Awake()
    {
        movementSys = player.GetComponent<IDialogueToUI>();
        interactionSys = gameObject.GetComponent<IInteractionRay>();
    }

    private void Update()
    {
        if(isOnUI == false)
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
    }

    void SendPosToMove()
    {
        Vector3 positionToMove = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 12)); // 12 в позиции Z является корректным для данной камеры
        movementSys.MoveTo(new Vector3(positionToMove.x, 0.1f, positionToMove.z));
    }

    public void OnUICHange(bool onUI) => isOnUI = onUI;
}
