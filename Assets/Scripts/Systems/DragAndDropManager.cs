using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropManager : MySystem, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    [SerializeField] private DragAndDropSystem dragAndDropSys;
    [SerializeField] private CanvasGroup canGroup;
    [SerializeField] private ItemSlotController myItemSlotController;
    [SerializeField] private DragAndDropSystem DragSys;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canGroup = GetComponent<CanvasGroup>();
        myItemSlotController = transform.GetComponentInParent<ItemSlotController>();
    }
    public ItemSlotController GetItemSlot() { return myItemSlotController; }

    public void OnBeginDrag(PointerEventData eventData)
    {
        print("OnBeginDrag");
        canGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(myItemSlotController.IsBusy() == true)
        {
            rectTransform.anchoredPosition += eventData.delta / dragAndDropSys.GetCanvas().scaleFactor;
        } 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = new Vector2(0,0);
        DragSys.GetDragingItemSlot = myItemSlotController;
        canGroup.blocksRaycasts = true;
    }
}
