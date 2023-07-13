using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;


using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;


public class NewsPanel : MonoBehaviour
{
    public GameObject buttonPrefab;
    public RectTransform content;
    public TextMeshProUGUI descriptionText;
    public Image newsImage;

    private const string newsApiUrl = "https://newsapi.org/v2/top-headlines";
    private const string apiKey = "66c878da83774259aeba01c129b2db2d";
    private const string newsSource = "bbc-news"; // Source ID for BBC News

    private NewsData newsData;

    void Start()
    {
        StartCoroutine(FetchNewsData());
    }

    IEnumerator FetchNewsData()
    {
        string url = $"{newsApiUrl}?sources={newsSource}&apiKey={apiKey}";

        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Failed to fetch news data: " + request.error);
            yield break;
        }

        string jsonResponse = request.downloadHandler.text;
        Debug.Log(jsonResponse);
        newsData = JsonUtility.FromJson<NewsData>(jsonResponse);

        if (newsData != null && newsData.articles.Length > 0)
        {
            PopulateNewsButtons();
        }
    }

    void PopulateNewsButtons()
    {
        foreach (ArticleData article in newsData.articles)
        {
            GameObject buttonGO = Instantiate(buttonPrefab, content);
            Button button = buttonGO.GetComponent<Button>();
            TextMeshProUGUI buttonText = buttonGO.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = article.title;

            button.onClick.AddListener(() => DisplayNewsDescription(article));
        }
    }

    void DisplayNewsDescription(ArticleData article)
    {
        descriptionText.text = article.description;

        // Check if image is available
        bool isImageAvailable = !string.IsNullOrEmpty(article.imageUrl);

        // Set image active/inactive based on availability
        newsImage.gameObject.SetActive(isImageAvailable);

        // Load news image (if available)
        if (isImageAvailable)
        {
            StartCoroutine(LoadImage(article.imageUrl));
        }
    }

    IEnumerator LoadImage(string imageUrl)
    {
        UnityWebRequest imageRequest = UnityWebRequestTexture.GetTexture(imageUrl);
        yield return imageRequest.SendWebRequest();

        if (imageRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Failed to load news image: " + imageRequest.error);
            yield break;
        }

        Texture2D texture = ((DownloadHandlerTexture)imageRequest.downloadHandler).texture;
        newsImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }
}

[System.Serializable]
public class NewsData
{
    public ArticleData[] articles;
}

[System.Serializable]
public class ArticleData
{
    public string title;
    public string description;
    public string imageUrl;
}
