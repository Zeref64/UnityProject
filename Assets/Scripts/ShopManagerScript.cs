using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    public int [,] shopItems = new int[5,5];
    public float coins;
    public Text CoinsTXT;

    void Start()
    {
        CoinsTXT.text= "Coins:" + coins.ToString();


        //ID's
        shopItems[1,1] = 1;
        shopItems[1,2] = 2;
        shopItems[1,3] = 3;
        shopItems[1,4] = 4;

        //Price
        shopItems[2,1] = 20;
        shopItems[2,2] = 45;
        shopItems[2,3] = 50;
        shopItems[2,4] = 10;

        //Quantity 
        shopItems[3,1] = 0;
        shopItems[3,2] = 0;
        shopItems[3,3] = 0;
        shopItems[3,4] = 0;
    }

    

    public void Buy()
    {
        GameObject ButtonRef = EventSystem.current.currentSelectedGameObject;

        if (ButtonRef != null)
        {
            ButtonInfo buttonInfo = ButtonRef.GetComponent<ButtonInfo>();
            if (buttonInfo != null)
            {
                int itemID = buttonInfo.ItemID;
                if (coins >= shopItems[2, itemID])
                {
                    coins -= shopItems[2, itemID];
                    shopItems[3, itemID]++;
                    CoinsTXT.text = "Coins:" + coins.ToString();
                    buttonInfo.QuantityTxt.text = shopItems[3, itemID].ToString();
                }
            }
        }
    }
}
