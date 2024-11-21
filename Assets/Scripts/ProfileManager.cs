using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{
    public PlayerData playerData;
    public Text usernameText;

    void Start()
    {
        playerData = SaveSystem.LoadPlayerData();
    }

    public void SaveProfile()
    {
        SaveSystem.SavePlayerData(playerData);
        Debug.Log("Player profile saved.");
    }


    public void UpdateCurrency(int caloriesBurned)
    {
        int currentCurrency = int.Parse(playerData.currency);
        currentCurrency += caloriesBurned; // Example reward logic
        playerData.currency = currentCurrency.ToString();
        Debug.Log($"Currency updated: {playerData.currency}");
    }


    public void AddWorkoutSession(WorkoutSession session)
    {
        if (playerData.workoutHistory == null)
        {
            playerData.workoutHistory = new List<WorkoutSession>();
        }

        playerData.workoutHistory.Add(session);
        Debug.Log($"Workout session added: {session.exerciseType}");
    }

    public void AddExperience(int xp){
        playerData.experience += xp;
        int requiredXP = GetExperienceForNextLevel(playerData.level);
        
        while (playerData.experience >= requiredXP)
        {
            playerData.experience -= requiredXP;
            playerData.level++;
            Debug.Log($"Level Up! You are now Level {playerData.level}");
            requiredXP = GetExperienceForNextLevel(playerData.level);
        }

        SaveProfile();

    }


    void LoadProfile()
    {
        string savedUsername = PlayerPrefs.GetString("Username", "New User");
        usernameText.text = "Welcome, " + savedUsername;
    }

    private int GetExperienceForNextLevel(int level){
        return 100 + (level - 1) * 50; // whatever just put this here for now
        
    }


}
