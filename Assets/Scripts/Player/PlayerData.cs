using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using JsonUtility to manage player data
[System.Serializable]
public class PlayerData
{
    public bool isFirstTimePlayer;
    public string currency;
    public List<WorkoutSession> workoutHistory;
    public List<string> unlockedCharacters;
    public string selectedCharacter;
    public string username;

    public int selectedCharacterIndex;

    public PlayerData()
    {
        // Default to true for a new player
        isFirstTimePlayer = true;

        // Empty until set by user
        username = "";

        //no character is seletced initially
        selectedCharacterIndex = -1;
    }
}

[Serializable]
public class WorkoutSession
{
    public string exerciseType;
    public int intensity;
    public float duration;
    public int caloriesBurned;
    public DateTime sessionDate;
}
