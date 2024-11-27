using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject gameManagerObject = new GameObject("GameManager");
                instance = gameManagerObject.AddComponent<GameManager>();
                DontDestroyOnLoad(gameManagerObject);

                // Optional: Initialize other systems if necessary
                instance.InitializeGameManager();
            }
            return instance;
        }
    }

    private SaveSystem saveSystem;

    private PlayerData playerData;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            InitializeGameManager();
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void InitializeGameManager()
    {

        saveSystem = SaveSystem.Instance;

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
            playerData.isFirstTimePlayer = false;

            //save the initial data
            saveSystem.SavePlayerData(playerData);

            Debug.Log("Account created successfully.");
        }
        else
        {


            Debug.Log("Welcome back!");
        }


    }

    public PlayerData GetPlayerData()
    {
        return playerData;
    }


    //add a workout session
    public void AddWorkoutSession(WorkoutSession session)
    {
        // Add the workout session to the player's history
        playerData.workoutHistory.Add(session);

        // Update records
        playerData.UpdateRecords(session);

        // Save updated data
        saveSystem.SavePlayerData(playerData);

        Debug.Log("Workout session added and records updated.");
    }


    // Add experience points to the player and handle level-ups
    public void AddExperience(int expAmount)
    {
        if (playerData != null)
        {
            playerData.experience += expAmount;

            while ((playerData.experience >= GetExperienceForNextLevel(playerData.level)))
            {
                // Check for level-up
                int requiredExp = GetExperienceForNextLevel(playerData.level);
                if (playerData.experience >= requiredExp)
                {
                    playerData.level++;
                    playerData.experience -= requiredExp; // Carry over remaining XP
                    Debug.Log($"Level up! New level: {playerData.level}");

                }
            }
            saveSystem.SavePlayerData(playerData);

            Debug.Log($"Experience updated. Current XP: {playerData.experience}, Level: {playerData.level}");
        }
        else
        {
            Debug.LogError("PlayerData is null. Cannot add experience.");
        }
    }

    // Calculate the experience required for the next level (example logic)
    private int GetExperienceForNextLevel(int currentLevel)
    {
        // Example: Required XP increases with the level
        return currentLevel * 100; // Example formula: 100 XP per level
    }

}
