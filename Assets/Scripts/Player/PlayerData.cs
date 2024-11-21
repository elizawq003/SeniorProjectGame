using System;
using System.Collections.Generic;
using UnityEngine;

// Serializable class for player data
[Serializable]
public class PlayerData
{
    // Whether the player is using the app for the first time
    public bool isFirstTimePlayer;

    // In-game currency (can represent points, coins, etc.)
    public string currency;

    // List of all completed workout sessions
    public List<WorkoutSession> workoutHistory;

    // List of unlocked character identifiers
    public List<string> unlockedCharacters;

    // Currently selected character's name or identifier
    public string selectedCharacter;

    // The player's username
    public string username;

    // The index of the selected character in the unlockedCharacters list
    public int selectedCharacterIndex;

    // Player's Level
    public int level;

    // Player's Experience
    public int experience;

    // Constructor initializes default values for a new player
    public PlayerData()
    {
        isFirstTimePlayer = true;
        username = "";
        currency = "0"; // Default currency value
        level = 1;
        experience = 0;
        selectedCharacterIndex = -1; // No character selected initially
        workoutHistory = new List<WorkoutSession>();
        unlockedCharacters = new List<string>();
    }
}

[Serializable]
public class WorkoutSession
{
    // The type of exercise performed (e.g., running, cycling)
    public string exerciseType;

    // The intensity of the exercise (1 = light, 2 = moderate, 3 = intense)
    public int intensity;

    // The duration of the workout in seconds
    public float duration;

    // Calories burned during this workout
    public int caloriesBurned;
    public string sessionDate = DateTime.Now.ToString("o"); // Store as ISO 8601 string

    // The date and time when this workout occurred
    public DateTime sessionDate;

    // Constructor for initializing workout session details
    public WorkoutSession(
        string exerciseType,
        int intensity,
        float duration,
        int caloriesBurned,
        DateTime sessionDate
    )
    {
        this.exerciseType = exerciseType;
        this.intensity = intensity;
        this.duration = duration;
        this.caloriesBurned = caloriesBurned;
        this.sessionDate = sessionDate;
    }
}
