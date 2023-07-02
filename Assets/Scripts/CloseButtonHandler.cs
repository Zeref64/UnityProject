using UnityEngine;
using UnityEngine.UI;

public class CloseButtonHandler : MonoBehaviour
{
    public DialogueUI dialogueUI; // Reference to the DialogueUI script

    private Button closeButton;

    private void Start()
    {
        closeButton = GetComponent<Button>();
        closeButton.onClick.AddListener(CloseDialogue);
    }

    private void CloseDialogue()
    {
        dialogueUI.CloseDialogueBox();
    }
}
