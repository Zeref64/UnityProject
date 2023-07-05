using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class ContactDataList
{
    public List<ContactData> contacts = new List<ContactData>();
}

public class ContactSaveLoad : MonoBehaviour
{
    private string savePath;

    private void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "contacts.json");
    }

    public void SaveContacts(List<ContactData> contacts)
    {
        ContactDataList contactDataList = new ContactDataList();
        contactDataList.contacts = contacts;

        string jsonData = JsonUtility.ToJson(contactDataList);
        File.WriteAllText(savePath, jsonData);
    }

    public List<ContactData> LoadContacts()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);

            ContactDataList contactDataList = JsonUtility.FromJson<ContactDataList>(json);

            return contactDataList.contacts;
        }
        else
        {
            Debug.LogWarning("ContactSaveLoad: Save file not found!");
            return new List<ContactData>();
        }
    }
}


