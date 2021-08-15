using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlotController : MySystem, IDropHandler
{
    [SerializeField] private GameObject curItemInSlot;
    [SerializeField] private bool isBusy;
    [SerializeField] private bool isEquipment;
    [SerializeField] private Image icon;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private DragAndDropSystem DragSys;
    

    private void Awake()
    {
        icon = transform.GetChild(0).GetComponent<Image>();
    }

    public GameObject AddOrRemoveItem
    { 
        get
        {
            return curItemInSlot; 
        }
        set
        {
            curItemInSlot = value;
        }
    }
    public bool IsBusy() { return isBusy; }
    public bool IsEquipment() { return isEquipment; }
    public void SlotInit(GameObject item)
    {
        isBusy = true;
        icon.sprite = item.GetComponent<Item>().GetItemInfo().GetIcon();
        curItemInSlot = item;
    }
    public void SlotClear()
    {
        isBusy = false;
        icon.sprite = defaultSprite;
        curItemInSlot = null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemSlotController tempDragItem = DragSys.GetDragingItemSlot;
        GameObject tempItem = tempDragItem.AddOrRemoveItem;
        if (isBusy) tempDragItem.SlotInit(curItemInSlot);
        else tempDragItem.SlotClear();
        SlotInit(tempItem);   
    }
}
