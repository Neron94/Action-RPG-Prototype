using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���������� ������� - ��������� ������������ �������� � ��������� � ����� ��������� ������
public class DialogueSystem : MySystem
{
    [SerializeField] private DIalogueToUi dialogueToUi;

    public void StartDialogue(SO_DialogueTree dialogueTree)
    {
        dialogueTree.GetDialogueNode();
    }

   
}
