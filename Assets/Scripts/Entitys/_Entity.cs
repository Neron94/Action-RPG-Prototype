using UnityEngine;

public class _Entity : MonoBehaviour
{
    //Базовый класс (бирка) для сущностей

    [SerializeField] string nameEntity;

    private void Awake()
    {
        nameEntity = gameObject.name;
    }

    public string GetName() { return nameEntity; }
}
