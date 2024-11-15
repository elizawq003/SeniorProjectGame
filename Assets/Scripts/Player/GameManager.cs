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

        // create an account if is a first timer user, else load the existing account 
        // made edits here -- Joonho
        if (playerData.isFirstTimePlayer)
        {
            Debug.Log("Please create an account.");
            SetupFirstTimeUser();
        }
        else
        {
            Debug.Log("Welcome back!" + playerData.username);
            LoadReturningUser();
        }
    }

    // made edits here -- Joonho
    private void SetupFirstTimeUser()
    {
        playerData.isFirstTimePlayer = false;
        playerData.username = ""; // Prompt for username in the UI
        playerData.currency = "0";
        SaveSystem.SavePlayerData(playerData);
    }

    // made edits here -- Joonho
    private void LoadReturningUser()
    {
        username = playerData.username;
        userPoints = int.Parse(playerData.currency);
    }

    public void AddPoints(int points)
    {
        userPoints += points;
    }

    // made edits here -- Joonho
    public void SetUsername(string name)
    {
        username = name;
        playerData.username = name;
        SaveSystem.SavePlayerData(playerData);
    }
}
