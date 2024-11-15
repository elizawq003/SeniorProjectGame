using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//handle saving and loading PlayerData to a JSON file
public static class SaveSystem
{
    private static readonly string filePath = Path.Combine(
        Application.persistentDataPath,
        "playerData.json"
    );

    //save player data to a file
    public static void SavePlayerData(PlayerData player)
    {
        // Check if filePath is correctly set
        if (string.IsNullOrEmpty(filePath))
        {
            Debug.LogError("filePath is not set!");
            return;
        }

        // Convert saved data to JSON
        string json = JsonUtility.ToJson(player, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Data saved.");
    }

    //load player data from file
    public static PlayerData LoadPlayerData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Debug.Log("Data loaded from " + filePath);
            return JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            // No existing file; return default data for first-time user
            Debug.Log("No existing file found, new player. Welcome!");
            return new PlayerData();
        }
    }
}
