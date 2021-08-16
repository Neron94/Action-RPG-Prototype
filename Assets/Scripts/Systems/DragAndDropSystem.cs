using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragAndDropSystem : MonoBehaviour
{
    [SerializeField] private Canvas mainCanvas;
    [SerializeField] private ItemSlotController dragingItem;
    [SerializeField] private bool isDraging = false;

    public bool IsDraging
    {
        get
        {
            return isDraging;
        }
        set
        {
            isDraging = value;
        }
    }

    public ItemSlotController GetDragingItemSlot 
    {
        get { return dragingItem; }
        set { dragingItem = value; }
    }
    public Canvas GetCanvas()
    {
        return mainCanvas;
    }
}
