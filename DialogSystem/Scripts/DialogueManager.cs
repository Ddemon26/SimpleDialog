using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

namespace DialogSystem
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance { get; private set; }
        private DialogueSequence currentDialogueSequence;
        [SerializeField] Button[] buttons;

        public event Action<DialogueEntry> OnDialogueUpdated;
        public event Action OnDialogueEnded;

        private int currentEntryIndex = 0;
        public bool IsDialogueActive { get; private set; }

        private void Awake()
        {
            Instance = this;
            IsDialogueActive = false;
            RegisterButtons();
        }
        private void OnDisable()
        {
            IsDialogueActive = false;
        }

        public void StartDialogue(DialogueSequence dialogueSequence)
        {
            currentDialogueSequence = dialogueSequence;
            currentEntryIndex = 0;
            IsDialogueActive = true;
            DisplayCurrentEntry();
        }
        public void EndDialogue()
        {
            currentDialogueSequence = null;
            IsDialogueActive = false;
            OnDialogueEnded?.Invoke();
        }
        public void SelectResponse(int responseIndex)
        {
            var responses = currentDialogueSequence.dialogueEntries[currentEntryIndex].responses;
            if (responseIndex < responses.Length)
            {
                var selectedResponse = responses[responseIndex];
                if (selectedResponse.nextDialogueSequence != null)
                {
                    StartDialogue(selectedResponse.nextDialogueSequence);
                }
                else
                {
                    EndDialogue();
                }
            }
        }
        public void DisplayNextEntry()
        {
            currentEntryIndex++;
            DisplayCurrentEntry();
        }
        public void DisplayPreviousEntry()
        {
            if (currentEntryIndex > 0)
            {
                currentEntryIndex--;
                DisplayCurrentEntry();
            }
        }
        public void DisplayEntry(int entryIndex)
        {
            if (entryIndex >= 0 && entryIndex < currentDialogueSequence.dialogueEntries.Length)
            {
                currentEntryIndex = entryIndex;
                DisplayCurrentEntry();
            }
        }


        void DisplayCurrentEntry()
        {
            if (currentEntryIndex < currentDialogueSequence.dialogueEntries.Length)
            {
                var currentEntry = currentDialogueSequence.dialogueEntries[currentEntryIndex];
                OnDialogueUpdated?.Invoke(currentEntry);

                // Enable or disable buttons based on the number of responses
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].gameObject.SetActive(i < currentEntry.responses.Length);
                }
            }
            else
            {
                EndDialogue();
            }
        }
        void RegisterButtons()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                int index = i; // Capture the loop variable
                buttons[i].onClick.AddListener(() => SelectResponse(index));
            }
        }
    }
}