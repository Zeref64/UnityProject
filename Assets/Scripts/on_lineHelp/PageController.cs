using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PageController : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI headerText;
    public TextMeshProUGUI bodyText;

    public Sprite[] images;
    public string[] headers;
    public string[] bodies;

    private int currentPageIndex = 0;

    private void Start()
    {
        ShowPage(currentPageIndex);
    }

    public void NextPage()
    {
        currentPageIndex++;
        if (currentPageIndex >= images.Length)
        {
            currentPageIndex = 0;
        }

        ShowPage(currentPageIndex);
    }

    public void PreviousPage()
    {
        currentPageIndex--;
        if (currentPageIndex < 0)
        {
            currentPageIndex = images.Length - 1;
        }

        ShowPage(currentPageIndex);
    }

    private void ShowPage(int index)
    {
        image.sprite = images[index];
        headerText.text = headers[index];
        bodyText.text = bodies[index];
    }
}
