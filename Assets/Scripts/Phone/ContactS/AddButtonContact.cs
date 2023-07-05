using UnityEngine;
using TMPro;

public class AddButtonContact : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private TMP_InputField numberInputField;
    [SerializeField] private ContactManager contactManager;

    public void OnAddButtonClick()
    {
        string name = nameInputField.text;
        string number = numberInputField.text;

        contactManager.AddContact(name, number);

        // Clear input fields after adding the contact
        nameInputField.text = "";
        numberInputField.text = "";
    }
}
