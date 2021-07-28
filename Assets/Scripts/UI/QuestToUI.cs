using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestToUI : MonoBehaviour, IQuestToUi
{
    [SerializeField] private List<Text> questName;
    [SerializeField] private List<Text> status;
    [SerializeField] private List<GameObject> allQuests;
    [SerializeField] private int questCount;
    [SerializeField] private int maxQuest = 4;

    private void Start()
    {
        HideQuestPanels();
    }

    public void SetQUestToUI(SO_Quest quest)
    {
        if(questCount < maxQuest) questCount++;
        HideQuestPanels();
        ShowQuestPanels();
        questName[questCount - 1].text = quest.GetQuestName();
        status[questCount - 1].text = "In progress";

    }
    private void ShowQuestPanels()
    {
        int iterationCounter = 0;
        while(questCount > iterationCounter)
        {
            allQuests[iterationCounter].SetActive(true);
            iterationCounter++;
        }
    }
    private void HideQuestPanels()
    {
        foreach (GameObject panel in allQuests)
        {
            panel.SetActive(false);
        }
    }
    public void RemoveQuest(SO_Quest quest)
    {
        if(questCount > 0) questCount--;
        HideQuestPanels();
        ShowQuestPanels();
    }
    
}
