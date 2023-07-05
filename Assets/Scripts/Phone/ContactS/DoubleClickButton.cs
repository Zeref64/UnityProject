using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DoubleClickButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float doubleClickThreshold = 0.3f;

    private float lastClickTime = 0f;
    private bool doubleClickFlag = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Time.time - lastClickTime <= doubleClickThreshold)
        {
            // Double click detected
            OnDoubleClick();
            doubleClickFlag = true;
        }
        else
        {
            doubleClickFlag = false;
        }

        lastClickTime = Time.time;
    }

    private void OnDoubleClick()
    {
        // Get the parent scroll view
        ScrollRect scrollRect = GetComponentInParent<ScrollRect>();
        if (scrollRect == null)
        {
            Debug.LogWarning("DoubleClickButton: ScrollRect not found in parent hierarchy!");
            return;
        }

        // Get the content transform of the scroll view
        Transform contentTransform = scrollRect.content;
        if (contentTransform == null)
        {
            Debug.LogWarning("DoubleClickButton: Content transform not found in ScrollRect!");
            return;
        }

        // Remove the button GameObject from the content
        Destroy(transform.gameObject);
        LayoutRebuilder.ForceRebuildLayoutImmediate(contentTransform as RectTransform);
        Canvas.ForceUpdateCanvases();

        // Get the ContactManager component
        ContactManager contactManager = FindObjectOfType<ContactManager>();
        if (contactManager == null)
        {
            Debug.LogWarning("DoubleClickButton: ContactManager not found in the scene!");
            return;
        }

        // Remove the contact from ContactManager
        contactManager.RemoveContact(transform.gameObject);
    }

    public bool WasDoubleClick()
    {
        return doubleClickFlag;
    }
}

