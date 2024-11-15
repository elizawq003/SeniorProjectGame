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

    public bool[] unlockedCharacters;

    public bool[] unlockedPets;

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

        //initially only one charatcer unlocked and no pets unlocked
        unlockedCharacters = new bool[24] {true,false, false, false, false, false, false, false,
            false,false,false,false,false,false,false,false,
        false,false,false,false,false,false,false,false};

        unlockedPets = new bool[8] {false, false, false, false, false, false, false, false };

    }

}
