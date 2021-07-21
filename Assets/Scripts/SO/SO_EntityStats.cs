using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityStats", menuName = "Stats/EntityStats",order = 1)]
public class SO_EntityStats : ScriptableObject
{
    [SerializeField] public float movSpeed;
    [SerializeField] public float rotSpeed;
}
