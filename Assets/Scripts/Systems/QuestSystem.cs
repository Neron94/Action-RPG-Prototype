using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MySystem, IQuestAdd, IExaminationQuest
{
    [SerializeField] private IQuestToUi questToUI;
    [SerializeField] private IInventoryManage inventoryManager;
    [SerializeField] private List<SO_Quest> ActiveQuests;
    [SerializeField] private List<SO_Quest> CompleteQuests;

    private void Awake()
    {
        questToUI = gameObject.GetComponent<IQuestToUi>();
        inventoryManager = gameObject.GetComponent<InventorySystem>();
    }
    private void QuestRemoveFromActive()
    {
        foreach(SO_Quest c_quest in CompleteQuests)
        {
            foreach(SO_Quest a_quest in ActiveQuests)
            {
                if (c_quest == a_quest)
                {
                    ActiveQuests.Remove(a_quest);
                    break;
                }
            }
        }
    }

    public void AddNewQuest(SO_Quest quest) 
    {
        ActiveQuests.Add(quest);
        questToUI.SetQuestToUI(quest);
        quest.QuestEventManage += QuestEnd;
    }
    public void QuestEnd(SO_Quest quest)
    {
        quest.QuestEventManage -= QuestEnd;
        questToUI.RemoveQuest(quest);
        CompleteQuests.Add(quest);
        quest.GetNpc().ChangeDialogueState = quest.GetStateOfDialogueToNpc();
    }
    public void ExaminationQuests()
    {
        foreach(SO_Quest quest in ActiveQuests)
        {
            if (Condition(quest))
            {
                quest.QuestComplete();
            }
        }
        QuestRemoveFromActive();
    }
    public bool Condition(SO_Quest quest)
    {
        if (inventoryManager.GetCountOfItemsInInventory(quest.GetQuestItem()) >= quest.GetQuestItemCount())
        {
            print("COndition OK");
            return true;
        }
        else
        {
            print(inventoryManager.GetCountOfItemsInInventory(quest.GetQuestItem()));
            return false;
        }
    }
    
}
