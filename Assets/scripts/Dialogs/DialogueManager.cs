using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueManager
{
    private static DialogueManager instance;
    private Dictionary<string, Dialogue> dialogueDict;

    private DialogueManager() {
        dialogueDict = new Dictionary<string, Dialogue>();

        DirectoryInfo dir = new DirectoryInfo("Assets/Resources/dialogues");
        FileInfo[] info = dir.GetFiles("*.json");
        foreach (FileInfo f in info)
        {
            Debug.Log(f.Name);
            dialogueDict.Add(f.Name.Split('.')[0], new Dialogue("dialogues/" + f.Name.Split('.')[0]));
        }

    }

    public static DialogueManager getInstance()
    {
        if (instance == null)
        {
            instance = new DialogueManager();
        }

        return instance;
    }

    public Dialogue getDialogue(string name) {
        return dialogueDict[name];
    }
}
