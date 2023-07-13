using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlarmManager : MonoBehaviour
{
    public TMP_InputField hourInputField;
    public TMP_InputField minuteInputField;
    public TMP_Text alarmDisplayText;
    public AudioSource alarmAudioSource;
    public AudioClip alarmSound;

    private List<DateTime> alarmList = new List<DateTime>();

    private void Start()
    {
        hourInputField.onEndEdit.AddListener(OnAlarmInputEndEdit);
        minuteInputField.onEndEdit.AddListener(OnAlarmInputEndEdit);
    }

    private void OnAlarmInputEndEdit(string unused)
    {
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            AddAlarm(hourInputField.text, minuteInputField.text);
        }
    }

    public void AddAlarm(string hour, string minute)
    {
        int hourValue;
        int minuteValue;

        if (int.TryParse(hour, out hourValue) && int.TryParse(minute, out minuteValue))
        {
            if (hourValue >= 0 && hourValue <= 23 && minuteValue >= 0 && minuteValue <= 59)
            {
                DateTime alarmDateTime = DateTime.Today.AddHours(hourValue).AddMinutes(minuteValue);
                alarmList.Add(alarmDateTime);
                hourInputField.text = string.Empty;
                minuteInputField.text = string.Empty;
            }
            else
            {
                Debug.LogWarning("Invalid hour or minute value. Please enter valid values (hour: 0-23, minute: 0-59).");
            }
        }
        else
        {
            Debug.LogWarning("Invalid hour or minute format. Please enter valid integer values.");
        }
    }

    private void Update()
    {
        DateTime currentTime = DateTime.Now;
        List<DateTime> triggeredAlarms = new List<DateTime>();

        foreach (DateTime alarm in alarmList)
        {
            if (alarm.Hour == currentTime.Hour && alarm.Minute == currentTime.Minute && alarm.Second == currentTime.Second)
            {
                Debug.Log("Alarm triggered!");
                triggeredAlarms.Add(alarm);
                // Add your desired actions when the alarm goes off
                PlayAlarmSound();
            }
        }

        foreach (DateTime triggeredAlarm in triggeredAlarms)
        {
            alarmList.Remove(triggeredAlarm);
        }

        UpdateAlarmDisplayText();
    }

    private void UpdateAlarmDisplayText()
    {
        alarmDisplayText.text = "Alarms: ";
        foreach (DateTime alarm in alarmList)
        {
            alarmDisplayText.text += alarm.ToString("HH:mm") + " ";
        }
    }

    private void PlayAlarmSound()
    {
        alarmAudioSource.clip = alarmSound;
        alarmAudioSource.Play();
    }
}
