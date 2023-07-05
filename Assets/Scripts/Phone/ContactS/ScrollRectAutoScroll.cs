using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ScrollRectAutoScroll : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float scrollSpeed = 10f;

    private bool isPointerOver;
    private ScrollRect scrollRect;

    private void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    private void Update()
    {
        if (isPointerOver)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            scrollRect.verticalNormalizedPosition += scroll * scrollSpeed * Time.deltaTime;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;
    }
}
