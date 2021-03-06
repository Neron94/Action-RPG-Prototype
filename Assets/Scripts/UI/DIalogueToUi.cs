using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//??????? ???????? ? ?????????
public class DIalogueToUi : MonoBehaviour, IDIalogueToUI
{
    [SerializeField] private INextDIalogue dialogueSystem;

    [SerializeField] private Text npcName;
    [SerializeField] private Text dialogue;
    [SerializeField] private List<Text> answers;
    [SerializeField] private List<Button> answerButtons;
    [SerializeField] private GameObject dialogueWindow;
    [SerializeField] private SO_DialogueNode curNode;

    private void Awake()
    {
        dialogueSystem = gameObject.GetComponent<INextDIalogue>();
    }
    private void Start()
    {
        EndDialogueWindow();
    }

    public void WriteNodeTextToUI(SO_DialogueNode node)
    {
        StartDialogueWindow();
        ActivateAllButtons();
        curNode = node;

        npcName.text = curNode.GetNpcName;
        dialogue.text = curNode.GetDialogueText;
        
        int answerCounter = 0;
        foreach (SO_DialogueNode.Answer answer in curNode.GetAnswerList)
        {
            answers[answerCounter].text = answer.GetText;
            answerCounter++;
        }
        DisableButton(answerCounter);
    }
    public void DisableButton(int numButtonCount)
    {
        int countOfButInUI = 4;
        while (countOfButInUI > numButtonCount)
        {
            answerButtons[countOfButInUI - 1].gameObject.SetActive(false);
            countOfButInUI--;
        }
    }
    public void ActivateAllButtons()
    {
        foreach (Button but in answerButtons) but.gameObject.SetActive(true);
    }
    public void StartDialogueWindow() { dialogueWindow.SetActive(true); }
    public void EndDialogueWindow() { dialogueWindow.SetActive(false); }
    public void AnswerClick(int butNum)
    {
        SO_DialogueNode.Answer answer = curNode.GetAnswerList[butNum];
        if (answer.HaveQuest())
        {
            if (!answer.IsEnd) dialogueSystem.NextDialogue(answer.GetNextNode, answer.GetNextStateId, answer.GetQuest());
            else dialogueSystem.EndDialogue();
        }
        else
        {
            if (!answer.IsEnd) dialogueSystem.NextDialogue(answer.GetNextNode, answer.GetNextStateId);
            else dialogueSystem.EndDialogue();
        }
        
    }
}
