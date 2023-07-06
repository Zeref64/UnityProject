using UnityEngine;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public AudioSource audioSource;
    public AudioClip buttonClickSound;
    private const int MaxCharacters = 15;

    private void Start()
    {
        if (audioSource == null)
        {
            // If AudioSource is not assigned, try to get it from the same GameObject
            audioSource = GetComponent<AudioSource>();
        }
    }

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

            // Play button click sound
            if (audioSource != null && buttonClickSound != null)
            {
                audioSource.PlayOneShot(buttonClickSound);
            }
        }
    }

    public void DeleteCharacter()
    {
        if (displayText != null && displayText.text.Length > 0)
        {
            // Remove the last character from the TextMeshPro text
            displayText.text = displayText.text.Substring(0, displayText.text.Length - 1);

            // Play button click sound
            if (audioSource != null && buttonClickSound != null)
            {
                audioSource.PlayOneShot(buttonClickSound);
            }
        }
    }
}