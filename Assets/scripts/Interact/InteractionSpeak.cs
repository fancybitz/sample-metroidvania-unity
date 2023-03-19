using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSpeak : Interaction
{
    public string dialogueName;
    private DialogueManager dialogueManager;

    void Awake() {
        DialogueManager dm = DialogueManager.getInstance();
        Dialogue dialogue = dm.getDialogue(dialogueName);
    }

    InteractionSpeak() {
        //dialogueManager.loadDialog(dialogueName);
    }

    public override void interact(Collider2D collision)
    {

    }
}
