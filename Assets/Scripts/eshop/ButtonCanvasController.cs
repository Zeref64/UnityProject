using UnityEngine;
using UnityEngine.UI;

public class ButtonCanvasController : MonoBehaviour
{
    public Canvas canvas; // Reference to the canvas you want to open/close
    public Button openButton; // Reference to the button that opens the canvas
    public Button closeButton; // Reference to the button that closes the canvas //! Error??

    private void Start()
    {
        // Add click listeners to the buttons
        
        openButton.onClick.AddListener(OpenCanvas);
        closeButton.onClick.AddListener(CloseCanvas); //! Error??

        // Close the canvas at the start
        canvas.gameObject.SetActive(false);
    }

    public void OpenCanvas()
    {
        canvas.gameObject.SetActive(true); // Open the canvas
    }

    public void CloseCanvas()
    {
        canvas.gameObject.SetActive(false); // Close the canvas
    }
}