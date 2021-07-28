using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INextDIalogue 
{
    public void NextDialogue(SO_DialogueNode node, int stateID);
    public void NextDialogue(SO_DialogueNode node, int stateID, SO_Quest quest);
    public void EndDialogue();
}
