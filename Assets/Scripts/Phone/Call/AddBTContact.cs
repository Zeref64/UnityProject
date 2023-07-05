using UnityEngine;
using TMPro;

public class AddBTContact : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private TextMeshProUGUI numberTextMesh;
    [SerializeField] private ContactManager contactManager;

    public GameObject inputFieldPanel; // Reference to the panel containing the input field
    private bool isInputFieldOpen = false;

    private void Update()
    {
        if (isInputFieldOpen)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                string name = nameInputField.text;
                string number = numberTextMesh.text;

                contactManager.AddContact(name, number);

                // Clear input fields after adding the contact
                nameInputField.text = "";
                numberTextMesh.text = "";

                CloseInputField();
            }
        }
    }


    public void OnAddButtonClick()
    {
        if (!isInputFieldOpen)
        {
            OpenInputField();
        }
        else
        {
            string name = nameInputField.text;
            string number = numberTextMesh.ToString();

            contactManager.AddContact(name, number);

            // Clear input fields after adding the contact
            nameInputField.text = "";
            numberTextMesh.text = "";

            CloseInputField();
        }
    }

    private void OpenInputField()
    {
        isInputFieldOpen = true;
        inputFieldPanel.SetActive(true);
        nameInputField.Select();
        nameInputField.ActivateInputField();
    }

    private void CloseInputField()
    {
        isInputFieldOpen = false;
        inputFieldPanel.SetActive(false);
    }
}
