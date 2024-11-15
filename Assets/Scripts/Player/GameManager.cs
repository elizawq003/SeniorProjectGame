using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerData playerData;
    public static GameManager instance;
    public int userPoints = 0;
    public string username = "";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keeps this object across scenes
        }
        else
        {
            Destroy(gameObject);
        }

        SaveSystem.LoadPlayerData();

        // Load player data to determine if this is a first-time user
        playerData = SaveSystem.LoadPlayerData();

        // Check if the player is a first-time user
        //create an account if is a first timer user, else load the existing account
        if (playerData.isFirstTimePlayer)
        {
            Debug.Log("Please create an account.");

            //create a new account
            playerData = new PlayerData();

            // Set up the new account by setting isFirstTimeUser to false
            playerData.isFirstTimePlayer = false;

            //save the initial data
            SaveSystem.SavePlayerData(playerData);

            Debug.Log("Account created successfully.");
        }
        else
        {
            Debug.Log("Welcome back!" + playerData.username);
        }
    }

    public void AddPoints(int points)
    {
        userPoints += points;
    }

    public void SetUsername(string name)
    {
        username = name;
    }
}
