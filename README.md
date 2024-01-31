# SimpleDialog
Simple Dialog Structure for unity.

DisplayDialogue Class
The DisplayDialogue class is part of the DialogSystem namespace and is responsible for managing the dialogue UI in a Unity game. It updates the UI to display the current dialogue entry and responses, and hides the UI when the dialogue ends.
Fields
•	dialogueManager: A reference to the DialogueManager instance that controls the dialogue system.
•	speakerNameText: A TextMeshProUGUI component that displays the name of the speaker.
•	dialogueText: A TextMeshProUGUI component that displays the current dialogue entry's text.
•	responseTexts: A list of TextMeshProUGUI components that display the responses to the current dialogue entry.
•	dialogueUI: A GameObject that contains all the dialogue UI elements.
Methods
•	OnEnable: Subscribes to the OnDialogueUpdated and OnDialogueEnded events of dialogueManager.
•	OnDestroy: Unsubscribes from the OnDialogueUpdated and OnDialogueEnded events of dialogueManager.
•	UpdateDialogueUI: Updates the dialogue UI to display the provided DialogueEntry. This method is called when the OnDialogueUpdated event of dialogueManager is invoked.
•	UpdateResponseTexts: Updates the response texts to display the responses of the provided DialogueEntry. This method is called by UpdateDialogueUI.
•	ClearDialogueUI: Clears the dialogue UI and hides it. This method is called when the OnDialogueEnded event of dialogueManager is invoked.
Usage
To use the DisplayDialogue class, attach it to a GameObject in your Unity scene, and assign the necessary references in the Inspector. The dialogueManager field should be a reference to your DialogueManager instance. The speakerNameText, dialogueText, and responseTexts fields should be references to TextMeshProUGUI components where the speaker name, dialogue text, and response texts will be displayed. The dialogueUI field should be a reference to the parent GameObject of all your dialogue UI elements.
When a dialogue starts, dialogueManager will invoke its OnDialogueUpdated event, which will call UpdateDialogueUI to update the dialogue UI. When a dialogue ends, dialogueManager will invoke its OnDialogueEnded event, which will call ClearDialogueUI to clear and hide the dialogue UI.

![image](https://github.com/Ddemon26/SimpleDialog/assets/95268795/9bc66065-8f9e-4491-99d5-3ebee72b52f8)


![image](https://github.com/Ddemon26/SimpleDialog/assets/95268795/d0c4ebd9-6efa-4a11-a976-b57901dea1ba)
