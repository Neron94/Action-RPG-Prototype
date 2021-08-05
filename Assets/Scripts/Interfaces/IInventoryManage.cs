using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryManage
{
    public void AddToInventory(GameObject item);
    public void RemoveFromList(GameObject item);
    public int GetCountOfItemsInInventory(GameObject item);
    
}
