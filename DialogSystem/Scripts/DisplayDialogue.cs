using UnityEngine;
using TMPro;
using System.Collections.Generic;

namespace DialogSystem
{
    public class DisplayDialogue : MonoBehaviour
    {
        [SerializeField] private DialogueManager dialogueManager;
        [SerializeField] private TextMeshProUGUI speakerNameText;
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private List<TextMeshProUGUI> responseTexts;
        [SerializeField] private GameObject dialogueUI;

        private int lastResponseCount = 0;

        private void OnEnable()
        {
            if (dialogueManager != null)
            {
                dialogueManager.OnDialogueUpdated += UpdateDialogueUI;
                dialogueManager.OnDialogueEnded += ClearDialogueUI;
            }
        }
        private void OnDestroy()
        {
            if (dialogueManager != null)
            {
                dialogueManager.OnDialogueUpdated -= UpdateDialogueUI;
                dialogueManager.OnDialogueEnded -= ClearDialogueUI;
            }
        }

        private void UpdateDialogueUI(DialogueEntry entry)
        {
            if (entry == null) return;

            speakerNameText.text = entry.speakerName;
            dialogueText.text = entry.sentence;

            UpdateResponseTexts(entry);
            dialogueUI.SetActive(true);
        }
        private void UpdateResponseTexts(DialogueEntry entry)
        {
            for (int i = 0; i < responseTexts.Count; i++)
            {
                bool isActive = i < entry.responses.Length;
                responseTexts[i].gameObject.SetActive(isActive);

                if (isActive)
                {
                    responseTexts[i].text = entry.responses[i].responseText;
                }
            }
            lastResponseCount = entry.responses.Length;
        }

        private void ClearDialogueUI()
        {
            speakerNameText.text = string.Empty;
            dialogueText.text = string.Empty;

            foreach (var responseText in responseTexts)
            {
                responseText.text = string.Empty;
                responseText.gameObject.SetActive(false);
            }

            dialogueUI.SetActive(false);
        }
    }
}