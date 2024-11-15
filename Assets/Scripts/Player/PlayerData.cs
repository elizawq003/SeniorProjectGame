using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using JsonUtility to manage player data
[System.Serializable]
public class PlayerData
{
    public bool isFirstTimePlayer;

    public string username;

    public int selectedCharacterIndex;

    public int coins;

    public PlayerData()
    {
        // Default to true for a new player
        isFirstTimePlayer = true;

        // Empty until set by user
        username = "";

        //no character is seletced initially
        selectedCharacterIndex = -1;

        //the initial amount of coins is 0
        coins = 0;
    }

}
