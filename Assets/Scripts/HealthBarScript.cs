using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider healthSlider;
    public TMP_Text healthBarText;

    Damageable playerDamageable;

    //private void Awake()
    //{
    //    GameObject player = GameObject.FindGameObjectWithTag("Player");

    //    if(player == null)
    //    {
    //        Debug.Log("No player found in the scene. make sure it gas tag 'Player'");
    //    }

    //}
    // Start is called before the first frame update
    //void Start()
    //{
    //    GameObject player = GameObject.FindGameObjectWithTag("Player");
    //    if (player == null)
    //    {
    //        Debug.LogError("No player found in the scene. Ensure it has the 'Player' tag.");
    //        return;
    //    }
    //    SetPlayer(player);
    //}

    public void SetPlayer(GameObject player)
    {
        playerDamageable = player.GetComponent<Damageable>();
        if (playerDamageable == null)
        {
            Debug.LogError("Player does not have a Damageable component.");
            return;
        }
        healthSlider.value = CalculateSliderPercentage(playerDamageable.Health, playerDamageable.MaxHealth);
        healthBarText.text = "HP " + playerDamageable.Health + " / " + playerDamageable.MaxHealth;

        playerDamageable.healthChanged.AddListener(OnPlayerHealthChanged);
    }
    private void OnDisable()
    {
        if (playerDamageable != null)
        {

            playerDamageable.healthChanged.RemoveListener(OnPlayerHealthChanged);
        }
    }
    private float CalculateSliderPercentage(float currentHealth, float maxHealth)
    {
        return currentHealth / maxHealth;
    }

    private void OnPlayerHealthChanged(int newHealh, int maxHealth)
    {
        healthSlider.value = CalculateSliderPercentage(newHealh, maxHealth);
        healthBarText.text = "HP " + newHealh + " / " + maxHealth;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
