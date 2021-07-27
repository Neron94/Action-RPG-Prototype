using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestTree", menuName = "QuestSystem/QuestTree", order = 1)]
public class SO_QuestTree : ScriptableObject
{
    [SerializeField] private string npcName;
    [SerializeField] private List<SO_Quest> allQuests;

    public SO_Quest GetQuest(int id)
    {
        if (allQuests.Count > 0) return allQuests[id];
        Debug.Log("Quest list in QuestTree is empty");
        return null;
    }
}
