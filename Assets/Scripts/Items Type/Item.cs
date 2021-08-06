using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteraction
{
    [SerializeField] private SO_ItemInfo itemInfo;
    [SerializeField] private static IInventoryManage inventoryManager;
    
    
    private void Start()
    {
        gameObject.name = itemInfo.GetItemName();
        inventoryManager = GameObject.Find("GameHandler").GetComponent<IInventoryManage>();
    }
    private void PickItem()
    {
        gameObject.SetActive(false);
        inventoryManager.AddToInventory(gameObject);
        transform.GetComponent<Rigidbody>().useGravity = false;
        transform.GetComponent<CapsuleCollider>().enabled = false;
    }

    public void Interact()
    {
        PickItem();
    }
}

