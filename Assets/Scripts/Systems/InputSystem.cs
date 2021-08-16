using UnityEngine;

//Система оперирует вводными данными игрока
public class InputSystem : MySystem, IOnUi
{
    [SerializeField] private IMoveTo movementSys;
    [SerializeField] private IInteractionRay interactionSys;
    [SerializeField] private IInventoryWindow inventoryWindowManager;
    [SerializeField] private bool isOnUI = false;
    [SerializeField] private GameObject player;

    private void Awake()
    {
        movementSys = player.GetComponent<IMoveTo>();
        interactionSys = gameObject.GetComponent<IInteractionRay>();
        inventoryWindowManager = gameObject.GetComponent<IInventoryWindow>();
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
        if (Input.GetKeyDown(KeyCode.I)) InventoryWindow();
    }
    private void SendPosToMove()
    {
        if (isOnUI == false)
        {
            Vector3 positionToMove = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 12)); // 12 в позиции Z является корректным для данной камеры
            movementSys.MoveTo(new Vector3(positionToMove.x, 0.1f, positionToMove.z));
        }
    }
    private void InventoryWindow()
    {
        inventoryWindowManager.InventoryWindowManager();
    }

    public void OnUICHange(bool onUI) => isOnUI = onUI;
    
}
