using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDIalogueToUI
{
    public void WriteNodeTextToUI(SO_DialogueNode node);
    public void EndDialogueWindow();
}
