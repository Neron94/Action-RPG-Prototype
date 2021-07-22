using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogeSystem", menuName = "DialogeSystem/DialogeNode", order = 1)]
public class SO_DialogueNode : ScriptableObject
{
    [SerializeField] string DialogueID;
    enum Actor
    {
        Object,
        NPC
    }
    [SerializeField] Actor ActorType;

    [SerializeField] List<string> DialogueText;
    [SerializeField] List<Answer> MyAnswer;

    [System.Serializable]
    public class Answer
    {
        [SerializeField] string text;
        [SerializeField] ScriptableObject NextDialogue;
        [SerializeField] bool isEnd;
    }



    


   
}

