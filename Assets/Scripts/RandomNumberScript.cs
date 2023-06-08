using UnityEngine;
using TMPro;

public class RandomNumberScript : MonoBehaviour
{
    public TextMeshProUGUI tmpText; // Reference to the TMP text component

    private void OnEnable()
    {
        GenerateRandomNumber();
    }

    private void GenerateRandomNumber()
    {
        int randomNumber = Random.Range(18, 26); // Generate a random number between 18 and 25 (inclusive)

        if (tmpText != null)
        {
            tmpText.text = randomNumber.ToString(); // Display the random number in the TMP text component
        }
        else
        {
            Debug.LogWarning("TMP text component reference is missing.");
        }
    }
}
