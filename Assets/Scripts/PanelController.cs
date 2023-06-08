using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelController : MonoBehaviour
{
    public GameObject panelToShow; // Reference to the panel to show
    public GameObject panelToFadeOut; // Reference to the panel to fade out
    public float fadeOutDelay = 2f; // Delay before fading out the second panel
    public float fadeOutDuration = 1f; // Duration of the fade out animation

    public void ShowPanel()
    {
        panelToShow.SetActive(true); // Set the panel to active (visible)
    }

    public void HidePanel()
    {
        panelToFadeOut.SetActive(true);
        StartCoroutine(FadeOutPanel()); // Start the fade out coroutine
    }

    private IEnumerator FadeOutPanel()
    {
        panelToShow.SetActive(false);
        yield return new WaitForSeconds(fadeOutDelay);

        Image panelImage = panelToFadeOut.GetComponent<Image>();
        TextMeshProUGUI panelText = panelToFadeOut.GetComponentInChildren<TextMeshProUGUI>();

        Color startColor = panelImage.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        float elapsedTime = 0f;

        while (elapsedTime < fadeOutDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = elapsedTime / fadeOutDuration;
            panelText.color = Color.Lerp(startColor, targetColor, normalizedTime);
            panelImage.color = Color.Lerp(startColor, targetColor, normalizedTime);
            yield return null;
        }

        panelToFadeOut.SetActive(false); // Set the panel to inactive (hidden)
    }


}