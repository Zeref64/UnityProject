using UnityEngine;
using UnityEngine.UI;

public class ShoppingListUI : MonoBehaviour
{
    public Text shoppingListText;
    public ShoppingList shoppingList;

    private void Update()
    {
        UpdateShoppingListText();
    }

    private void UpdateShoppingListText()
    {
        shoppingListText.text = "Shopping List:\n";
        foreach (string item in shoppingList.GetItems())
        {
            shoppingListText.text += "- " + item + "\n";
        }
    }
}