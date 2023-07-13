using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DigitalClock : MonoBehaviour
{
    public TextMeshProUGUI clockText;

    private void Start()
    {
        InvokeRepeating("UpdateClock", 0f, 1f);
    }

    private void UpdateClock()
    {
        DateTime currentTime = DateTime.Now;
        clockText.text = currentTime.ToString("HH:mm:ss");
    }
}
