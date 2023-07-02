using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private int openObject;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CloseDialogueBox();
        }
    }

    private void OpenDialogueBox()
    {
        dialogueBox.SetActive(true);
    }

    public void CloseDialogueBox()
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
