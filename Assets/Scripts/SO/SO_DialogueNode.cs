using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Диалоговая переменная
[CreateAssetMenu(fileName = "DialogeSystem", menuName = "DialogeSystem/DialogeNode", order = 1)]
public class SO_DialogueNode : ScriptableObject
{
    [SerializeField] private string DialogueID;
    enum Actor
    {
        Object,
        NPC
    }
    [SerializeField] private Actor ActorType;

    [SerializeField] private List<string> DialogueText;
    [SerializeField] private List<Answer> MyAnswer;

    [System.Serializable]
    public class Answer
    {
        [SerializeField] string text;
        [SerializeField] ScriptableObject NextDialogue;
        [SerializeField] bool isEnd;
    }

    public List<string> GetDialogueText { get { return DialogueText; } }
}

