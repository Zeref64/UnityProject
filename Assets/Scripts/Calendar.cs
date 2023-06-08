using UnityEngine;
using TMPro;

public class Calendar : MonoBehaviour
{
    public TextMeshProUGUI dateText;

    private void Start()
    {
        DisplayCurrentDate();
    }

    private void DisplayCurrentDate()
    {
        string currentDate = System.DateTime.Now.ToString("dd MMMM yyyy");
        dateText.text = currentDate;
    }
}
