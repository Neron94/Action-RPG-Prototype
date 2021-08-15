using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MySystem, IInventoryManage
{
    [SerializeField] private List<GameObject> itemsList;
    [SerializeField] private IExaminationQuest questExamine;
    [SerializeField] private IInventoryToUi inventoryToUi;

    private void Awake()
    {
        questExamine = gameObject.GetComponent<IExaminationQuest>();
        inventoryToUi = gameObject.GetComponent<IInventoryToUi>();
    }
    
    public List<GameObject> GetInventory() { return itemsList; }
    public void AddToInventory(GameObject item)
    {
        itemsList.Add(item);
        questExamine.ExaminationQuests();
        inventoryToUi.AddItemsToUI(itemsList);
    }
    public int GetCountOfItemsInInventory(GameObject item)
    {
        var count = 0;
        foreach(GameObject q_item in itemsList)
        {
            if (q_item.name == item.name) count++;
        }
        return count;
    }
    public void RemoveFromList(GameObject item) { itemsList.Remove(item); }
}
