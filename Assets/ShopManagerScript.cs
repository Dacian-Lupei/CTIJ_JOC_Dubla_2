using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{

    public int[,] shopItems = new int[5,5];
    public TMP_Text CoinText;
    public GameObject player;
    public int coinC; 
    // Start is called before the first frame update
    void Start()
    {
        //ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        //Price
        shopItems[2, 1] = 5;
        shopItems[2, 2] = 5;
        shopItems[2, 3] = 5;
        shopItems[2, 4] = 5;

        //Quantity
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;


    }

    public void Buy()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (player.GetComponent<PlayerController>().coinCount >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().itemID] && buttonRef.GetComponent<ButtonInfo>().itemID == 1)
        {
            player.GetComponent<PlayerController>().coinCount -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().itemID];
            player.GetComponent<PlayerController>().jumpImpulse = player.GetComponent<PlayerController>().jumpImpulse + 2;
            shopItems[3, buttonRef.GetComponent<ButtonInfo>().itemID] = shopItems[3, buttonRef.GetComponent<ButtonInfo>().itemID] + 2;
            CoinText.text = "Coins: " + player.GetComponent<PlayerController>().coinCount.ToString();
            buttonRef.GetComponent<ButtonInfo>().quantityText.text = shopItems[3, buttonRef.GetComponent<ButtonInfo>().itemID].ToString();
        }
        if (player.GetComponent<PlayerController>().coinCount >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().itemID] && buttonRef.GetComponent<ButtonInfo>().itemID == 2)
        {
            player.GetComponent<PlayerController>().coinCount -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().itemID];
            player.GetComponent<PlayerController>().walkSpeed = player.GetComponent<PlayerController>().walkSpeed + 2;
            shopItems[3, buttonRef.GetComponent<ButtonInfo>().itemID] = shopItems[3, buttonRef.GetComponent<ButtonInfo>().itemID] + 2;
            CoinText.text = "Coins: " + player.GetComponent<PlayerController>().coinCount.ToString();
            buttonRef.GetComponent<ButtonInfo>().quantityText.text = shopItems[3, buttonRef.GetComponent<ButtonInfo>().itemID].ToString();
        }
        if (player.GetComponent<PlayerController>().coinCount >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().itemID] && buttonRef.GetComponent<ButtonInfo>().itemID == 3)
        {
            player.GetComponent<PlayerController>().coinCount -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().itemID];
            player.GetComponent<PlayerController>().airWalkSpeed = player.GetComponent<PlayerController>().airWalkSpeed + 2;
            shopItems[3, buttonRef.GetComponent<ButtonInfo>().itemID] = shopItems[3, buttonRef.GetComponent<ButtonInfo>().itemID] + 2;
            CoinText.text = "Coins: " + player.GetComponent<PlayerController>().coinCount.ToString();
            buttonRef.GetComponent<ButtonInfo>().quantityText.text = shopItems[3, buttonRef.GetComponent<ButtonInfo>().itemID].ToString();
        }

        if (player.GetComponent<PlayerController>().coinCount >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().itemID] && buttonRef.GetComponent<ButtonInfo>().itemID == 4)
        {
            player.GetComponent<PlayerController>().coinCount -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().itemID];
            //Attack.attackDamage += 2;
            shopItems[3, buttonRef.GetComponent<ButtonInfo>().itemID] = shopItems[3, buttonRef.GetComponent<ButtonInfo>().itemID] + 2;
            CoinText.text = "Coins: " + player.GetComponent<PlayerController>().coinCount.ToString();
            buttonRef.GetComponent<ButtonInfo>().quantityText.text = shopItems[3, buttonRef.GetComponent<ButtonInfo>().itemID].ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        coinC = player.GetComponent<PlayerController>().coinCount;
        CoinText.text = "Coins: " + coinC.ToString();
    }
}
