using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject canvas;     //ανοιγει επομενο object
    [SerializeField] private int openObject;        //σε περιπτωση =1
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
        if (openObject == 1)
            canvas.SetActive(true);
    }

    public void StartDialogue()
    {
        typewriter.Run(dialogueText, textLabel);
        StartCoroutine(CompleteDialogue());
    }

    private System.Collections.IEnumerator CompleteDialogue()
    {
        yield return new WaitForSeconds(10f);
        CloseDialogueBox();
    }
}
