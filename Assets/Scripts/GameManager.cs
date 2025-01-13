using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class GameManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] characterPrefabs;
    public CinemachineVirtualCamera virtualCamera;
    public CoinManager cm;
    public ShopManagerScript sm;

    //de la Varu
    //public int cc = 100;

    // Start is called before the first frame update
    void Start()
    {
        int selectedOption = PlayerPrefs.GetInt("selectedOption", 0);
        DontDestroyOnLoad(gameObject);
        if (selectedOption >= 0 && selectedOption < characterPrefabs.Length)
        {
            GameObject character = Instantiate(characterPrefabs[selectedOption], spawnPoint.position, Quaternion.identity);
            character.tag = "Player";
            HealthBarScript healthBar = FindAnyObjectByType<HealthBarScript>();
            if(healthBar != null)
            {
                healthBar.SetPlayer(character);
            }
            AssignDependacies(character);
        }
        else 
        {
            Debug.LogError("Invalid character index. No character spawned");
        }
    }


    private void AssignDependacies(GameObject character)
    {
        if(virtualCamera != null)
        {
            virtualCamera.Follow = character.transform;
            virtualCamera.LookAt = character.transform;
        }
        if (cm != null) 
        {
            cm.SetPlayer(character);
        }
        if(sm != null)
        {
            sm.SetPlayer(character);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
