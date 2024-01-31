using System;
using UnityEngine;

namespace DialogSystem
{
    //Model AKA Data Object.
    [CreateAssetMenu(fileName = "New DialogueSequence", menuName = "Dialogue System/DialogueSequence")]
    public class DialogueSequence : ScriptableObject
    {
        public DialogueEntry[] dialogueEntries;
    }
    [Serializable]
    public class DialogueEntry
    {
        public string speakerName;
        [TextArea(3, 10)]
        public string sentence;
        public DialogueResponse[] responses;
    }
    [Serializable]
    public class DialogueResponse
    {
        [TextArea(2, 5)]
        public string responseText;
        public DialogueSequence nextDialogueSequence;
    }
}