using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coinCounter;
    public TMP_Text coinText;
    public GameObject player;
    
    //de la Varu
    //public GameManager gm;
    //public int cc;
    // Start is called before the first frame update

    public void SetPlayer(GameObject playerObject)
    {
        player = playerObject;
        Debug.Log("CoinManager assigned to player: " + player.name);

    }
    void Start()
    {
        //de la varu
        //gm = GameManager.FindFirstObjectByType<GameManager>();
        //cc = gm.cc;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = ": " + player.GetComponent<PlayerController>().coinCount.ToString();
    }

}
