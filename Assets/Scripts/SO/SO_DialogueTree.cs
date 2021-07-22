using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Список диалогов и значение текущего состояния диалогов с НПС
[CreateAssetMenu(fileName = "DialogeSystem", menuName = "DialogeSystem/DialogeTree", order = 1)]
public class SO_DialogueTree : ScriptableObject
{
    [SerializeField] private int curDialogueState = 1;
    [SerializeField] private List<SO_DialogueNode> allDialogues;

    public int ChangeDialogueState { set { curDialogueState = value; } }
    public SO_DialogueNode GetDialogueNode() { return allDialogues[curDialogueState - 1]; }
}
