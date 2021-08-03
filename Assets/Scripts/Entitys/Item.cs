using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteraction
{
    [SerializeField] private SO_ItemInfo itemInfo;
    
    private void Start()
    {
        gameObject.name = itemInfo.GetItemName();
    }
    
    public void PickItem()
    {
        gameObject.SetActive(false);
    }

    public void Interact()
    {
        PickItem();
    }
}

