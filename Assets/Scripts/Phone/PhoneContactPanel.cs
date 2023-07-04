using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhoneContactPanel : MonoBehaviour
{
    public GameObject contactButtonPrefab; // Prefab of the button to instantiate for each contact
    public Transform contactButtonContainer; // Container for the contact buttons within the scroll view
    public PhoneContactPanel phoneContactPanel; // Reference to the PhoneContactPanel component

    public void AddContact(string contactName, string contactNumber)
    {
        // Instantiate a new contact button from the prefab
        GameObject newButton = Instantiate(contactButtonPrefab, contactButtonContainer);
        
        // Set the button's label text to the contact information
        TMP_Text buttonText = newButton.GetComponentInChildren<TMP_Text>();
        buttonText.text = $"{contactName}: {contactNumber}";
    }


    public void AddNewContact(string contactName, string contactNumber)
    {
        // Call the AddContact() method of the PhoneContactPanel component
        phoneContactPanel.AddContact(contactName, contactNumber);
    }
}