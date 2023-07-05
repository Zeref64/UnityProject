using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class WeatherController : MonoBehaviour
{
    public TextMeshProUGUI temperatureText;
    public Image iconImage;
    public Sprite dayIcon;
    public Sprite nightIcon;
    public Sprite cloudyIcon;
    public Sprite rainyIcon;

    private const string APIKey = "67efa6dcf96741e883692637230507";
    private const string BaseURL = "http://api.weatherapi.com/v1/current.json";
    private const string Location = "Athens";

    private void Start()
    {
        StartCoroutine(GetWeatherData());
    }

    private IEnumerator GetWeatherData()
    {
        string requestURL = $"{BaseURL}?key={APIKey}&q={Location}";

        using (UnityWebRequest request = UnityWebRequest.Get(requestURL))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError($"Error: {request.error}");
            }
            else
            {
                string responseJson = request.downloadHandler.text;
                WeatherData weatherData = JsonUtility.FromJson<WeatherData>(responseJson);
                if (weatherData != null)
                {
                    float temperature = weatherData.current.temp_c;
                    temperatureText.text = $"{temperature}°C";

                    string weatherCondition = weatherData.current.condition.text;
                    UpdateWeatherIcon(weatherCondition);
                }
            }
        }
    }

    private void UpdateWeatherIcon(string condition)
    {
        if (condition.Contains("cloudy"))
        {
            System.DateTime currentTime = System.DateTime.Now;
            bool isDaytime = (currentTime.Hour >= 6 && currentTime.Hour < 18);

            if (isDaytime)
            {
                iconImage.sprite = cloudyIcon;
            }
            else
            {
                iconImage.sprite = cloudyIcon;
            }
        }
        else if (condition.Contains("rain"))
        {
            iconImage.sprite = rainyIcon;
        }
        else
        {
            System.DateTime currentTime = System.DateTime.Now;
            bool isDaytime = (currentTime.Hour >= 6 && currentTime.Hour < 18);

            if (isDaytime)
            {
                iconImage.sprite = dayIcon;
            }
            else
            {
                iconImage.sprite = nightIcon;
            }
        }
    }
}

[System.Serializable]
public class WeatherData
{
    public CurrentData current;
}

[System.Serializable]
public class CurrentData
{
    public float temp_c;
    public ConditionData condition;
}

[System.Serializable]
public class ConditionData
{
    public string text;
}
