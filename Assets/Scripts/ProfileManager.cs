using System.Collections.Generic;
using UnityEngine;

public class ProfileManager : MonoBehaviour
{
    public static ProfileManager Instance { get; private set; }

    public PlayerData playerData;

    private void Awake()
    {
        // Singleton pattern to ensure only one ProfileManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadProfile(); // Load player data on startup
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Save the current profile data to persistent storage
    public void SaveProfile()
    {
        if (playerData != null)
        {
            SaveSystem.SavePlayerData(playerData);
            Debug.Log("Profile saved successfully.");
        }
        else
        {
            Debug.LogError("PlayerData is null. Cannot save profile.");
        }
    }

    // Load the profile data from persistent storage
    public void LoadProfile()
    {
        playerData = SaveSystem.LoadPlayerData();

        if (playerData == null)
        {
            Debug.LogWarning("No save file found. Creating a new profile.");
            playerData = new PlayerData(); // Initialize a new player profile
            SaveProfile(); // Save the newly created profile
        }
        else
        {
            Debug.Log("Profile loaded successfully.");
        }
    }

    // Add a completed workout session to the player's history
    public void AddWorkoutSession(WorkoutSession session)
    {
        if (playerData != null)
        {
            if (playerData.workoutHistory == null)
            {
                playerData.workoutHistory = new List<WorkoutSession>();
            }

            // Add the new workout session to the history
            playerData.workoutHistory.Add(session);
        }
        else
        {
            Debug.LogError("PlayerData is null. Cannot add workout session.");
        }
    }


    // Update the player's in-game currency based on a reward (e.g., calories burned)
    public void UpdateCurrency(int amount)
    {
        if (playerData != null)
        {
            if (int.TryParse(playerData.currency, out int currentCurrency))
            {
                currentCurrency += amount;
                playerData.currency = currentCurrency.ToString();
                Debug.Log($"Currency updated. New balance: {playerData.currency}");
            }
            else
            {
                Debug.LogError("Currency value is invalid.");
            }
        }
        else
        {
            Debug.LogError("PlayerData is null. Cannot update currency.");
        }
    }

    // Add experience points to the player and handle level-ups
    public void AddExperience(int expAmount)
    {
        if (playerData != null)
        {
            playerData.experience += expAmount;

            // Check for level-up
            int requiredExp = GetExperienceForNextLevel(playerData.level);
            if (playerData.experience >= requiredExp)
            {
                playerData.level++;
                playerData.experience -= requiredExp; // Carry over remaining XP
                Debug.Log($"Level up! New level: {playerData.level}");
            }

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
