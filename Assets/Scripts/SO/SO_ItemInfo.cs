using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName = "Item System/Item", order = 1)]
public class SO_ItemInfo : ScriptableObject
{
    [SerializeField] private string itemName;
    private enum itemEnum { Weapon, Armor, QuestItem };
    [SerializeField] itemEnum itemType;

    public string GetItemName()
    {
        return itemName;
    }
}
