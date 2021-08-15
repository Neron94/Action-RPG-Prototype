using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvetoryToUI : MySystem, IInventoryToUi, IInventoryWindow
{
    [SerializeField] private List<ItemSlotController> itemSlotsInventory;
    [SerializeField] private List<ItemSlotController> equipmentSlots;
    [SerializeField] private GameObject InventoryWindow;
    [SerializeField] private bool isInventoryOpen = false;

    private void Awake()
    {
        //Включение выключение меню инвенторя при помощи изменения скейла
        InventoryWindow.transform.localScale = new Vector3(0, 0, 0);
        isInventoryOpen = false;
    }
    private void ClearAllSlots()
    {
        foreach (ItemSlotController item in itemSlotsInventory)
        {
            item.SlotClear();
        }
    }
    
    public void AddItemsToUI(List<GameObject> items)
    {
        ClearAllSlots();
        int counter = 0;
        foreach(GameObject item in items)
        {
            ItemSlotController Slot = itemSlotsInventory[counter].GetComponent<ItemSlotController>();
            Slot.SlotInit(item);
            counter++;
        }
    }
    public void InventoryWindowManager()
    {
        if (isInventoryOpen)
        {
            InventoryWindow.transform.localScale = new Vector3(0,0,0);
            isInventoryOpen = false;
        }
        else
        {
            InventoryWindow.transform.localScale = new Vector3(1, 1, 1);
            isInventoryOpen = true;
        }
    }
    
}
