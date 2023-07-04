using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddItemButton : MonoBehaviour
{
    public TMP_InputField itemInputField;
    public ShoppingList shoppingList;

    public void AddItemToList()
    {
        string newItem = itemInputField.text;
        shoppingList.AddItem(newItem);
        itemInputField.text = string.Empty;
    }
}
