using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string PlayerDataPath = Application.persistentDataPath + "/playerData.dat";

    // Save player data
    public static void SavePlayerData(PlayerData playerData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fileStream = new FileStream(PlayerDataPath, FileMode.Create))
        {
            formatter.Serialize(fileStream, playerData);
            Debug.Log($"Player data saved at: {PlayerDataPath}");
        }
    }

    // Load player data
    public static PlayerData LoadPlayerData()
    {
        if (File.Exists(PlayerDataPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream(PlayerDataPath, FileMode.Open))
            {
                PlayerData data = formatter.Deserialize(fileStream) as PlayerData;
                Debug.Log("Player data loaded.");
                return data;
            }
        }
        else
        {
            Debug.LogError("No save file found at: " + PlayerDataPath);
            return null;
        }
    }
}
