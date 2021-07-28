using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MySystem, IQuestAdd
{
    private IQuestToUi questToUI;
    [SerializeField] private List<SO_Quest> ActiveQuests;
    [SerializeField] private List<SO_Quest> CompleteQuests;

    private void Awake()
    {
        questToUI = gameObject.GetComponent<IQuestToUi>();
    }

    public void AddNewQuest(SO_Quest quest) 
    {
        ActiveQuests.Add(quest);
        questToUI.SetQUestToUI(quest);
    }
    public void QuestComplete(SO_Quest quest)
    {
        questToUI.RemoveQuest(quest);
        ActiveQuests.Remove(quest);
        CompleteQuests.Add(quest);
    }
}
