using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.IO;



public class ContactButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI numberText;

    public string GetNameText()
    {
        return nameText.text;
    }

    public void SetContactData(string name, string number)
    {
        nameText.text = name;
        numberText.text = number;
    }
    
    public void OnButtonClick()
    {
        // Implement the behavior when the contact button is clicked, if needed.
    }
}
