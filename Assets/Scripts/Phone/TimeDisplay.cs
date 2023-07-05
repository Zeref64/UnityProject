using UnityEngine;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    private void Start()
    {
        InvokeRepeating("UpdateTime", 0f, 1f); // Update time every second
    }

    private void UpdateTime()
    {
        string currentTime = System.DateTime.Now.ToString("HH:mm:ss"); // Format the current time

        if (timeText != null)
        {
            timeText.text = currentTime; // Update the TextMeshPro text
        }
    }
}

