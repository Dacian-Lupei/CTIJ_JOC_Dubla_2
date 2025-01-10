using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Void : MonoBehaviour
{
    public GameObject player;
    public Transform RespawnPoint;
    public GameObject enemy;
    public int SceneReset = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //player.transform.position = RespawnPoint.position;
            SceneManager.LoadScene("MainScene");
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(enemy);
        }
    }
}
