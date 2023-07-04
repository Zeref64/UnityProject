using UnityEngine;

public class PhoneController : MonoBehaviour
{
    public GameObject[] panels; // Array of panels to manage

    private GameObject activePanel; // Currently active panel

    public void OpenPanel(int panelIndex)
    {
        // Check if the clicked panel index is valid
        if (panelIndex >= 0 && panelIndex < panels.Length)
        {
            // Close the active panel if one is already open
            if (activePanel != null)
            {
                activePanel.SetActive(false);
            }

            // Open the selected panel
            GameObject panelToOpen = panels[panelIndex];
            panelToOpen.SetActive(true);
            activePanel = panelToOpen;
        }
    }
}

