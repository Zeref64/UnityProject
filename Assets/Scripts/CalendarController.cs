using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CalendarController : MonoBehaviour
{
    private DateTime currentDate;
    private string[] months;
    public TextMeshProUGUI headerLabel;
    public GameObject buttonPrefab;
    public Transform buttonContainer;
    public float buttonSpacing = 10f;
    public int daysPerRow = 7;

    private void Start()
    {
        currentDate = DateTime.Now;
        CreateMonths();
        UpdateCalendar();
    }

    private void CreateMonths()
    {
        months = new string[12];

        for (int i = 0; i < 12; ++i)
        {
            DateTime month = new DateTime(1, i + 1, 1);
            months[i] = month.ToString("MMMM");
        }
    }

    private void UpdateCalendar()
    {
        int daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
        DateTime firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
        int startingIndex = GetDays(firstDayOfMonth.DayOfWeek);

        headerLabel.text = months[currentDate.Month - 1] + " " + currentDate.Year;

        // Clear existing buttons
        foreach (Transform child in buttonContainer)
        {
            Destroy(child.gameObject);
        }

        // Calculate the starting position for the buttons
        RectTransform buttonRect = buttonPrefab.GetComponent<RectTransform>();
        float startX = -daysPerRow / 2f * (buttonRect.rect.width + buttonSpacing) + buttonRect.rect.width / 2f;
        float startY = (buttonRect.rect.height + buttonSpacing) / 2f;

        // Calculate the total height of the buttons
        int numRows = (daysInMonth + startingIndex + daysPerRow - 1) / daysPerRow;
        float totalButtonHeight = numRows * (buttonRect.rect.height + buttonSpacing);

        // Create buttons for each day
        for (int i = 0; i < daysInMonth + startingIndex; i++)
        {
            int rowIndex = i / daysPerRow;
            int columnIndex = i % daysPerRow;

            int buttonDay = i - startingIndex + 1;

            GameObject buttonGO = Instantiate(buttonPrefab, buttonContainer);
            Button button = buttonGO.GetComponent<Button>();
            button.interactable = true;

            // Check if the buttonDay is within the valid range for the month
            if (buttonDay >= 1 && buttonDay <= daysInMonth)
            {
                button.GetComponentInChildren<TextMeshProUGUI>().text = buttonDay.ToString();
            }
            else
            {
                // Display an empty label for days outside the month's range
                button.GetComponentInChildren<TextMeshProUGUI>().text = string.Empty;
                button.interactable = false;
            }

            // Add an event listener to the button
            button.onClick.AddListener(() => ToggleButton(button));

            // Set button position within the container
            RectTransform buttonRectTransform = buttonGO.GetComponent<RectTransform>();
            buttonRectTransform.localScale = Vector3.one;
            buttonRectTransform.localPosition = new Vector3(startX + columnIndex * (buttonRect.rect.width + buttonSpacing), startY - rowIndex * (buttonRect.rect.height + buttonSpacing), 0f);
        }
    }

    private int GetDays(DayOfWeek day)
    {
        switch (day)
        {
            case DayOfWeek.Sunday: return 0;
            case DayOfWeek.Monday: return 1;
            case DayOfWeek.Tuesday: return 2;
            case DayOfWeek.Wednesday: return 3;
            case DayOfWeek.Thursday: return 4;
            case DayOfWeek.Friday: return 5;
            case DayOfWeek.Saturday: return 6;
            default: throw new Exception("Unexpected DayOfWeek: " + day);
        }
    }

  private void ToggleButton(Button button)
{
    Color originalColor = button.colors.normalColor;
    Color selectedColor = button.colors.selectedColor;

    // Check if the button is already in the selected state
    bool isSelected = button.GetComponent<Image>().color == selectedColor;

    // Toggle the selected state of the button
    isSelected = !isSelected;

    // Update the button color based on the selected state
    if (isSelected)
    {
        // Set the color to the selected color
        button.GetComponent<Image>().color = selectedColor;
    }
    else
    {
        // Revert the color to the original color
        button.GetComponent<Image>().color = originalColor;
    }
}

    public void NextMonth()
    {
        currentDate = currentDate.AddMonths(1);
        UpdateCalendar();
    }

    public void PreviousMonth()
    {
        currentDate = currentDate.AddMonths(-1);
        UpdateCalendar();
    }
}
