using System.Collections.Generic;
using UnityEngine;

public class ShoppingList : MonoBehaviour
{
    private List<string> shoppingItems = new List<string>();

    public void AddItem(string item)
    {
        shoppingItems.Add(item);
    }

    public void RemoveItem(string item)
    {
        shoppingItems.Remove(item);
    }

    public void DisplayList()
    {
        Debug.Log("Shopping List:");
        foreach (string item in shoppingItems)
        {
            Debug.Log(item);
        }
    }

    public List<string> GetItems()
    {
        return shoppingItems;
    }


}

