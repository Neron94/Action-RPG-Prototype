using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INextDIalogue 
{
    public void NextDialogue(SO_DialogueNode node);
    public void EndDialogue();
}
