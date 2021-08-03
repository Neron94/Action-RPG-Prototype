using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestSystem", menuName = "QuestSystem/QuestSystem", order = 1)]
public class SO_Quest : ScriptableObject
{
    [SerializeField] private SO_DialogueTree npc;
    [SerializeField] private string questName;
    [SerializeField] private int ToStateIfComplete;


    private event Action<SO_Quest> QuestCompleteEvent;
    public void QuestEventInvoke()
    {
        QuestCompleteEvent?.Invoke(this);
    }
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
        npc.ChangeDialogueState = ToStateIfComplete;
        QuestEventInvoke();
    }
}
