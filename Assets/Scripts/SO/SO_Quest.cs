using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestSystem", menuName = "QuestSystem/Quest", order = 1)]
public class SO_Quest : ScriptableObject
{
    [SerializeField] private SO_DialogueTree npc;
    [SerializeField] private string questName;
    [SerializeField] private int ToStateIfComplete;

    [SerializeField] private GameObject questItem;
    [SerializeField] private int questItemCount;


    private event Action<SO_Quest> QuestCompleteEvent;
    private void QuestEventInvoke()
    {
        QuestCompleteEvent?.Invoke(this);
    }

    public GameObject GetQuestItem() { return questItem; }
    public int GetQuestItemCount() { return questItemCount; }
    public SO_DialogueTree GetNpc() { return npc; }
    public int GetStateOfDialogueToNpc() { return ToStateIfComplete; }
    public event Action<SO_Quest> QuestEventManage
    {
        add
        {
            QuestCompleteEvent += value;
        }
        remove
        {
            QuestCompleteEvent -= value;
        }
    }
    public string GetQuestName() { return questName; }
    
    public void QuestComplete()
    {
        Debug.Log("Quest Complete");
        QuestEventInvoke();
    }

}
