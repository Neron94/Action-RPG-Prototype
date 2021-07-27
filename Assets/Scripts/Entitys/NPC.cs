using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������� �������� � ��������� ��� ���
public class NPC : _Entity, IInteraction
{
    [SerializeField] private DialogueSystem dialogueSystem;
    [SerializeField] private SO_DialogueTree npcDialogueTree;
    [SerializeField] private SO_QuestTree npcQuestTree;

    public void Interact()
    {
        dialogueSystem.StartDialogue(npcDialogueTree);
    }
}
