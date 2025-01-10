using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int itemID;
    public TMP_Text priceText;
    public TMP_Text quantityText;
    public GameObject ShopManager;
    // Update is called once per frame
    void Update()
    {
        priceText.text = "Price: € " + ShopManager.GetComponent<ShopManagerScript>().shopItems[2,itemID].ToString();
        quantityText.text = "+ " + ShopManager.GetComponent<ShopManagerScript>().shopItems[3,itemID].ToString();
    }
}
