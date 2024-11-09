using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    private SaveSystem saveSystem;

    private PlayerData playerData;

    

    private void Start()
    {

        saveSystem = new SaveSystem();

        // Load player data to determine if this is a first-time user
        playerData = saveSystem.LoadPlayerData();

        // Check if the player is a first-time user
        //create an account if is a first timer user, else load the existing account
        if (playerData.isFirstTimePlayer)
        {
            Debug.Log("Please create an account.");

            //create a new account
            playerData = new PlayerData();

            // Set up the new account by setting isFirstTimeUser to false
            playerData.isFirstTimePlayer= false;

            //save the initial data
            saveSystem.SavePlayerData(playerData);

            Debug.Log("Account created successfully.");
        }
        else
        {
            

            Debug.Log("Welcome back!");
        }

        
    }
}
