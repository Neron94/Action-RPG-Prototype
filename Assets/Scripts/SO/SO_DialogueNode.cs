using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Диалоговая переменная
[CreateAssetMenu(fileName = "DialogeSystem", menuName = "DialogeSystem/DialogeNode", order = 1)]
public class SO_DialogueNode : ScriptableObject
{
    [SerializeField] private string npcName;
    [SerializeField] private string DialogueID;
    enum Actor
    {
        Object,
        NPC
    }
    [SerializeField] private Actor ActorType;

    [SerializeField] private string DialogueText;
    [SerializeField] private List<Answer> MyAnswer;

    public string GetNpcName { get { return npcName; } }
    public List<Answer> GetAnswerList { get { return MyAnswer; } }
    public string GetDialogueText { get { return DialogueText; } }
    [System.Serializable]
    public class Answer
    {
        [SerializeField] private string text;
        [SerializeField] private SO_DialogueNode NextDialogue;
        [SerializeField] private bool isEnd;
        [SerializeField] private int nextStateId;
        [SerializeField] private SO_Quest questStartNode;

        public bool HaveQuest() 
        {
            if (questStartNode != null) return true;
            else return false;
        }
        public SO_Quest GetQuest()
        {
            return questStartNode;
        }
        public string GetText { get { return text; } }
        public SO_DialogueNode GetNextNode
        {
            get
            {
                if (!isEnd) return NextDialogue;
                else
                {
                    Debug.Log("In This Node NextDialogue is Empty");
                    return null;
                }
            }
        }
        public bool IsEnd => isEnd;
        public int GetNextStateId { get { return nextStateId; } }
    }

}

