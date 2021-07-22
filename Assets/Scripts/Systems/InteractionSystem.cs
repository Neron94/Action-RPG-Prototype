using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MySystem
{

    [SerializeField] float interactionDistace = 2; //По умолчанию для этой сцены

    public GameObject IsHaveObjectOnRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
        Physics.Raycast(ray, out rayHit, 100f);

        if (rayHit.collider.gameObject)
        {
            GameObject curGameobject = rayHit.collider.gameObject;
            float distPlayerObject = Vector3.Distance(transform.position, curGameobject.transform.position);

            if (distPlayerObject <= interactionDistace)
            {
                curGameobject.GetComponent<IInteraction>().Interact();
                return rayHit.collider.gameObject;
            }
            else return null;
  
        }
        else return null;
    }

    /*
    void OnWhoCollide()
    {
        switch (gameObject.tag)
        {
            case "NPC":
                break;
            case "Item":
                break;
        }
    }*/
}
