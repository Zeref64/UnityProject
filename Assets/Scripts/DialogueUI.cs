using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [TextArea(3, 10)] [SerializeField] private string dialogueText;

    private Typewriter typewriter;

    private void Start()
    {
        typewriter = GetComponentInChildren<Typewriter>();
        OpenDialogueBox();
        StartDialogue();
    }

    private void OpenDialogueBox()
    {
        dialogueBox.SetActive(true);
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }

    public void StartDialogue()
    {
        typewriter.Run(dialogueText, textLabel);
        StartCoroutine(CompleteDialogue());
    }

    private System.Collections.IEnumerator CompleteDialogue()
    {
        yield return new WaitForSeconds(5f);
        CloseDialogueBox();
    }
}
