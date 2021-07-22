using UnityEngine;

//Базовый класс (бирка) для сущностей
public class _Entity : MonoBehaviour
{
    [SerializeField] string nameEntity;

    private void Awake()
    {
        nameEntity = gameObject.name;
    }

    public string GetName() { return nameEntity; }
}
