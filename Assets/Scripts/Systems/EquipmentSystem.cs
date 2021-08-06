using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSystem : MySystem
{
    [SerializeField] private GameObject weaponPointOne;
    [SerializeField] private GameObject weaponPointTwo;
    [SerializeField] private bool isEquipedOne;
    [SerializeField] private bool isEquipedTwo;

    public void EquipItem(GameObject item, int slot)
    {
        switch (slot)
        {
            case 1:
                item.transform.parent = weaponPointOne.transform;
                item.transform.localPosition = new Vector3(0,0,0);
                item.transform.localRotation = Quaternion.identity;
                isEquipedOne = true;
                break;
            case 2:
                item.transform.parent = weaponPointTwo.transform;
                item.transform.localPosition = new Vector3(0, 0, 0);
                item.transform.localRotation = Quaternion.identity;
                isEquipedTwo = true;
                break;
        }
    }
    
    public void UnEquipItem()
    {

    }
    public bool IsInInventory(GameObject weapon)
    {
        return true; 
    }
}
