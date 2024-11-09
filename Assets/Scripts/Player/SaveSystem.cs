using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//handle saving and loading PlayerData to a JSON file
public class SaveSystem : MonoBehaviour
{
    private string filePath;


    //define the file path
    private void Awake()
    {
        // Set file path to the persistent data path
        filePath = Path.Combine(Application.persistentDataPath, "playerData.json");

        Debug.Log("Save path: " + filePath); // Log the file path for debugging
    }

    //save player data to a file
    public void SavePlayerData(PlayerData player)
    {

        // Check if filePath is correctly set
        if (string.IsNullOrEmpty(filePath))
        {
            Debug.LogError("filePath is not set!");
            return;
        }


        // Convert saved data to JSON
        string json = JsonUtility.ToJson(player, true);

        // Write JSON to file
        File.WriteAllText(filePath, json);

        Debug.Log("Data saved.");
    }

    //load player data from file
    public PlayerData LoadPlayerData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            return JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            // No existing file; return default data for first-time user

            return new PlayerData();
        }
    }

    
}
