using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using JsonUtility to manage player data
[Serializable]
public class PlayerData
{
    // made changes -- Joonho
    public bool isFirstTimePlayer;
    public string currency;
    public List<WorkoutSession> workoutHistory;
    public List<string> unlockedCharacters;
    public string selectedCharacter;
    public string username;

    // made changes -- Joonho
    public int selectedCharacterIndex = -1;

    public PlayerData()
    {
        isFirstTimePlayer = true;

        // Empty until set by user
        username = "";

        //no character is seletced initially
        selectedCharacterIndex = -1;
        workoutHistory = new List<WorkoutSession>();
        unlockedCharacters = new List<string>();
    }
}

[Serializable]
public class WorkoutSession
{
    public string exerciseType;
    public int intensity;
    public float duration;
    public int caloriesBurned;
    public string sessionDate = DateTime.Now.ToString("o"); // Store as ISO 8601 string

    public DateTime GetSessionDate()
    {
        DateTime.TryParse(sessionDate, out var date);
        return date;
    }
}
