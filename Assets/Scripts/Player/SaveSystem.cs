using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//handle saving and loading PlayerData to a JSON file
public class SaveSystem : MonoBehaviour
{
    //make sure that save system is implmented as singleton
    private static SaveSystem instance;

    private string filePath;


    public static SaveSystem Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject saveSystemObject = new GameObject("SaveSystem");
                instance = saveSystemObject.AddComponent<SaveSystem>();
                DontDestroyOnLoad(saveSystemObject);
            }
            return instance;
        }
    }

    //define the file path
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

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
