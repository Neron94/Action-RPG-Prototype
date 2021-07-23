using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Верстка диалогов в Интерфейс
public class DIalogueToUi : MonoBehaviour, IDIalogueToUI
{
    [SerializeField] private INextDIalogue diaSysNextDialogue;

    [SerializeField] private Text npcName;
    [SerializeField] private Text dialogue;
    [SerializeField] private List<Text> answers;
    [SerializeField] private List<Button> answerButtons;
    [SerializeField] private GameObject dialogueWindow;
    [SerializeField] private SO_DialogueNode curNode;

    private void Awake()
    {
        diaSysNextDialogue = gameObject.GetComponent<INextDIalogue>();
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
    
    public void OperateButtonClick(int butNum)
    {
        SO_DialogueNode.Answer answer = curNode.GetAnswerList[butNum];
        if (!answer.IsEnd) diaSysNextDialogue.NextDialogue(curNode.GetAnswerList[butNum].GetNextNode);
        else diaSysNextDialogue.EndDialogue();

    }
}
