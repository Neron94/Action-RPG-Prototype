using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Система обеспечивает проверку Интерактивна ли сущность по которой произошел клик
public class InteractionSystem : MySystem, IInteractionRay
{
    [SerializeField] private float interactionDistace = 2; //Оптимальная дистанция до интерактивного обьекта По умолчанию для этой сцены
    [SerializeField] private GameObject player;

    public GameObject IsHaveObjectOnRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
        Physics.Raycast(ray, out rayHit, 100f);

        if (rayHit.collider.gameObject)
        {
            GameObject curGameobject = rayHit.collider.gameObject;
            float distPlayerObject = Vector3.Distance(player.transform.position, curGameobject.transform.position);

            if (distPlayerObject <= interactionDistace)
            {
                curGameobject.GetComponent<IInteraction>().Interact();
                return rayHit.collider.gameObject;
            }
            else return null;
  
        }
        else return null;
    }
}
    