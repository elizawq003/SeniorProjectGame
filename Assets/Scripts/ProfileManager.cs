using System;
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
    }

    public void UpdateCurrency(int amount)
    {
        playerData.currency += amount;
        SaveProfile();
    }

    public void AddWorkoutSession(WorkoutSession session)
    {
        playerData.workoutHistory.Add(session);
        SaveProfile();
    }

    void LoadProfile()
    {
        string savedUsername = PlayerPrefs.GetString("Username", "New User");
        usernameText.text = "Welcome, " + savedUsername;
    }
}
