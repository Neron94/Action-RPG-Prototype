using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestSystem", menuName = "QuestSystem/QuestSystem", order = 1)]
public class SO_Quest : ScriptableObject
{
    [SerializeField] private SO_DialogueTree npc;
    [SerializeField] private string questDescription;
    [SerializeField] private int ToStateIfComplete;
    [SerializeField] private enum Qtype { killTarget, GetItem };
    [SerializeField] private Qtype QuestType;

    private event Action OnQuestComplete;
    private void OnEnable()
    {
        OnQuestComplete += QuestComplete;
    }

    public void QuestEventInvoke()
    {
        OnQuestComplete?.Invoke();
    }
    public event Action QuestEventManage
    {
        add
        {
            OnQuestComplete += value;
        }
        remove
        {
            OnQuestComplete -= value;
        }
    }
    public void QuestComplete()
    {
        Debug.Log("Quest Complete");
        npc.ChangeDialogueState = ToStateIfComplete;
    }
}
