using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������� �������� � ��������� ��� ���
public class NPC : _Entity, IInteraction
{
    [SerializeField] private DialogueSystem dialogueSystem;
    [SerializeField] private SO_DialogueTree npcDialogueTree;

    public void Interact()
    {
        dialogueSystem.StartDialogue(npcDialogueTree);
    }
}
