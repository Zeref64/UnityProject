using UnityEngine;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    private const int MaxCharacters = 15;

    public void UpdateDisplay(string value)
    {
        if (displayText != null)
        {
            // Append the clicked button value to the TextMeshPro text
            displayText.text += value;

            // Check if the text length exceeds the maximum characters
            if (displayText.text.Length > MaxCharacters)
            {
                displayText.text = displayText.text.Substring(0, MaxCharacters);
            }
        }
    }

    public void DeleteCharacter()
    {
        if (displayText != null && displayText.text.Length > 0)
        {
            // Remove the last character from the TextMeshPro text
            displayText.text = displayText.text.Substring(0, displayText.text.Length - 1);
        }
    }
}
