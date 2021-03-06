using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName = "Item System/Item", order = 1)]
public class SO_ItemInfo : ScriptableObject
{
    [SerializeField] private string itemName;
    private enum itemEnum { Weapon, Armor, QuestItem };
    [SerializeField] private itemEnum itemType;
    [SerializeField] private float itemWeight;
    [SerializeField] private Sprite itemIcon;

    public Sprite GetIcon() { return itemIcon; }
    public string GetItemName()
    {
        return itemName;
    }
}
