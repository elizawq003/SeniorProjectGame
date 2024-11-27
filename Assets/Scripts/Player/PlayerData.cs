using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//using JsonUtility to manage player data
[System.Serializable]
public class PlayerData
{
    // Whether the player is using the app for the first time
    public bool isFirstTimePlayer;

    public string username;

    public int selectedCharacterIndex;

    public int seletcedPetIndex;

    public int coins;

    public bool[] unlockedCharacters;

    public bool[] unlockedPets;

    // List of all completed workout sessions
    public List<WorkoutSession> workoutHistory;

    // Player's Level
    public int level;

    // Player's Experience
    public int experience;


    // New fields for tracking records
    public int highestCaloriesBurnt;       // Highest calories burnt in one session
    public float longestWorkoutDuration;  // Longest workout duration in seconds


    // Constructor initializes default values for a new player
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

        ////no pet is seletced initially
        seletcedPetIndex = -1;

        level = 1;

        experience = 0;

        workoutHistory = new List<WorkoutSession>();

        // Initialize records
        highestCaloriesBurnt = 0;
        longestWorkoutDuration = 0f;

        //initially only one charatcer unlocked and no pets unlocked
        unlockedCharacters = new bool[24] {true,false, false, false, false, false, false, false,
            false,false,false,false,false,false,false,false,
        false,false,false,false,false,false,false,false};

        unlockedPets = new bool[8] {false, false, false, false, false, false, false, false };



    }

    // Method to update the highest records based on a completed workout
    public void UpdateRecords(WorkoutSession session)
    {
        if (session.caloriesBurned > highestCaloriesBurnt)
        {
            highestCaloriesBurnt = session.caloriesBurned;
        }

        if (session.duration > longestWorkoutDuration)
        {
            longestWorkoutDuration = session.duration;
        }
    }

}


[System.Serializable]
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