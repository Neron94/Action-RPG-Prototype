using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MySystem
{ 
    [SerializeField] private List<SO_Quest> ActiveQuests;
    [SerializeField] private List<SO_Quest> CompleteQuests;

    public void AddNewQuest(SO_Quest quest) { ActiveQuests.Add(quest); }
    public void QuestComplete(SO_Quest quest)
    { 
        ActiveQuests.Remove(quest);
        CompleteQuests.Add(quest);
    }
}
