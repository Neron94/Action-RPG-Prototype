using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MySystem, IInventoryManage
{
    [SerializeField] private List<GameObject> itemsList;
    [SerializeField] private IExaminationQuest questExamine;

    private void Awake()
    {
        questExamine = gameObject.GetComponent<IExaminationQuest>();
    }
    public List<GameObject> GetInventory() { return itemsList; }
    public void AddToInventory(GameObject item)
    {
        itemsList.Add(item);
        questExamine.ExaminationQuests();
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
