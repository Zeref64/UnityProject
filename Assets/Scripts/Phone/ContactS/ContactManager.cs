using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ContactManager : MonoBehaviour
{
    [SerializeField] private GameObject contactButtonPrefab;
    [SerializeField] private Transform contentTransform;
    [SerializeField] private VerticalLayoutGroup layoutGroup;
    // [SerializeField] private string filePath = "contacts.json";

    private List<ContactData> contactList = new List<ContactData>();
    private List<GameObject> contactButtonList = new List<GameObject>();

    private ContactSaveLoad contactSaveLoad;

    private void Awake()
    {
        contactSaveLoad = GetComponent<ContactSaveLoad>();
    }

    private void Start()
    {
        LoadContacts();
    }

    public void AddContact(string name, string number)
    {
        ContactData newContact = new ContactData(name, number);
        contactList.Add(newContact);

        // Instantiate a new contact button and set its text values
        GameObject contactButtonObj = Instantiate(contactButtonPrefab, contentTransform);
        ContactButton contactButton = contactButtonObj.GetComponent<ContactButton>();
        contactButton.SetContactData(newContact.Name, newContact.Number);

        // Add the button to the list
        contactButtonList.Add(contactButtonObj);

        // Adjust the layout to accommodate the new button
        LayoutRebuilder.ForceRebuildLayoutImmediate(contentTransform as RectTransform);

        contactSaveLoad.SaveContacts(contactList);
    }

    public void RemoveContact(GameObject contactButtonObj)
    {
        // Get the contact button component
        ContactButton contactButton = contactButtonObj.GetComponent<ContactButton>();

        // Get the contact name from the contact button text
        string contactName = contactButton.GetNameText();

        // Remove the contact from the list
        ContactData contactToRemove = contactList.Find(contact => contact.Name == contactName);
        contactList.Remove(contactToRemove);

        // Remove the contact button from the list
        contactButtonList.Remove(contactButtonObj);

        // Destroy the contact button object
        Destroy(contactButtonObj);

        // Adjust the layout after removing the button
        LayoutRebuilder.ForceRebuildLayoutImmediate(contentTransform as RectTransform);

        // Save the updated contact list to the JSON file
        contactSaveLoad.SaveContacts(contactList);
    }

    public void ClearContacts()
    {
        // Destroy all contact buttons
        foreach (GameObject contactButtonObj in contactButtonList)
        {
            Destroy(contactButtonObj);
        }

        // Clear the contact list and button list
        contactList.Clear();
        contactButtonList.Clear();
    }

    public void ReloadContacts()
    {
        // Clear existing contact buttons
        ClearContacts();

        // Load contacts from the JSON file
        LoadContacts();
    }

    private void LoadContacts()
    {
        contactList = contactSaveLoad.LoadContacts();

        foreach (ContactData contactData in contactList)
        {
            // Instantiate a new contact button and set its text values
            GameObject contactButtonObj = Instantiate(contactButtonPrefab, contentTransform);
            ContactButton contactButton = contactButtonObj.GetComponent<ContactButton>();
            contactButton.SetContactData(contactData.Name, contactData.Number);

            // Add the button to the list
            contactButtonList.Add(contactButtonObj);
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(contentTransform as RectTransform);
    }
}
