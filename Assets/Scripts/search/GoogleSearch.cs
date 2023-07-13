using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GoogleSearch : MonoBehaviour
{
    public TMP_InputField searchInputField;

    public void PerformSearch()
    {
        string query = searchInputField.text;
        string url = "https://www.google.com/search?q=" + WWW.EscapeURL(query);
        Application.OpenURL(url);
    }
}

