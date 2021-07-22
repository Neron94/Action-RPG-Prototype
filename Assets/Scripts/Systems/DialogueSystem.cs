using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Диалоговая система - командует отображением диалогов в Интерфейс а также Запускает диалог
public class DialogueSystem : MySystem
{
    [SerializeField] private DIalogueToUi dialogueToUi;

    public void StartDialogue(SO_DialogueTree dialogueTree)
    {
        dialogueTree.GetDialogueNode();
    }

   
}
