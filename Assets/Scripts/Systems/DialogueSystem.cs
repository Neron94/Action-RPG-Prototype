using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Диалоговая система - командует отображением диалогов в Интерфейс а также Запускает диалог
public class DialogueSystem : MySystem, INextDIalogue
{
    [SerializeField] private IDIalogueToUI dialogueToUi;
    [SerializeField] private SO_DialogueTree curDialogueTree;
    
    private void Awake()
    {
        dialogueToUi = gameObject.GetComponent<IDIalogueToUI>();
    }
    
    public void StartDialogue(SO_DialogueTree dialogueTree)
    {
        curDialogueTree = dialogueTree;
        dialogueToUi.WriteNodeTextToUI(curDialogueTree.GetDialogueNode());
    }
    public void StartDialogue(SO_DialogueNode dialogueNode)
    {
        dialogueToUi.WriteNodeTextToUI(dialogueNode);
    }
    public void EndDialogue()
    {
        dialogueToUi.EndDialogueWindow();
    }
    public void NextDialogue(SO_DialogueNode node, int stateID)
    {
        curDialogueTree.ChangeDialogueState = stateID;
        StartDialogue(node);
    }
}
