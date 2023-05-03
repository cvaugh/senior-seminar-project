using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour {
    public int playerLevel;
    public Text levelNumText;

    public int playerCoins;
    public Text coinNumText;

    //public Text S;

    void Start()
    {
        playerCoins = 100;
    }

    void Update()
    {
        playerCoins = getPlayerCoins();
    }

    [ContextMenu("Increase Level")]
    public void increaseLevel() {
        playerLevel++;
        levelNumText.text = playerLevel.ToString();
    }

    [ContextMenu("Increase Coins")]
    /* Add parameter to function so it can accept "num of coins to add" */
    public void increaseCoins() {
        playerCoins++;
        coinNumText.text = playerCoins.ToString();
    }

    [ContextMenu("Decrease Coins")]
    /* Add parameter to function so it can accept "num of coins to take" */
    public void decreaseCoins() {
        playerCoins--;
        coinNumText.text = playerCoins.ToString();
    }

    [ContextMenu("Input Player Name")]
    public void setPlayerName() {
       
    }

    public int getPlayerCoins()
    {
        return playerCoins;
    }
}
