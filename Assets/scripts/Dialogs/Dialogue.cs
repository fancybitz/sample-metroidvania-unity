using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Dialogue
{
    private TextAsset targetFile;
    private Container container;
    private string dialogueName;

    public Dialogue(string dialogueName) {
        this.dialogueName = dialogueName;

        loadDialogue();
    }

    public void loadDialogue()
    {
        // loading dialog by file name
        targetFile = Resources.Load<TextAsset>(dialogueName);
        // serializing from json string to Container
        container = JsonUtility.FromJson <Container>(targetFile.ToString());

        if (container != null) {
            Debug.Log("Loaded dialogue: " + dialogueName);
        }
    }

    public Container getDialogue() {
        return container;
    }

    [Serializable]
    public class Container
    {
        [field: SerializeField] public State[] states;

        public State getStartingState() {
            if (states != null && states.Length > 0)
            {
                foreach (State state in states)
                {
                    if (state == null) {
                        continue;
                    }

                    if (state.start) { 
                        return state;
                    }
                }
            }

            return null;
        }

        public State getNextState(Transition transition) {
            if (transition != null) {
                return getState(transition.next_id);
            }

            return null;
        }

        public State getState(int id)
        {
            if (states != null && states.Length > 0)
            {
                foreach (State state in states)
                {
                    if (state == null)
                    {
                        continue;
                    }

                    if (state.id == id)
                    {
                        return state;
                    }
                }
            }

            return null;
        }
    }

    [Serializable]
    public class State
    {
        [field: SerializeField] public bool start;
        [field: SerializeField] public int id;
        [field: SerializeField] public string sentence;
        [field: SerializeField] public Transition[] transitions;
    }

    [Serializable]
    public class Transition {
        [field: SerializeField] public string sentence;
        [field: SerializeField] public int next_id;
    }
}