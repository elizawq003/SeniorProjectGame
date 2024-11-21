using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogInSceneController : MonoBehaviour
{
    private PlayerData playerData;

    public TMP_Text welcomeText;
    public TMP_InputField usernameInput;

    private void Start()
    {
        // Check for missing references in the Inspector
        if (welcomeText == null)
        {
            Debug.LogError("WelcomeText is not assigned in the Inspector.");
        }

        if (usernameInput == null)
        {
            Debug.LogError("UsernameInput is not assigned in the Inspector.");
        }

        // Load player data
        playerData = SaveSystem.LoadPlayerData();

        // If no saved data exists, initialize a new PlayerData object
        if (playerData == null)
        {
            Debug.LogWarning("No player data found. Initializing new PlayerData.");
            playerData = new PlayerData();
        }

        // Check if this is a first-time user
        if (playerData.isFirstTimePlayer)
        {
            welcomeText.text = "Welcome! Please create an account.";
            usernameInput.gameObject.SetActive(true);
        }
        else
        {
            welcomeText.text = "Welcome back!";
            usernameInput.gameObject.SetActive(false);
        }
    }

    public void OnContinueButtonClicked()
    {
        if (playerData.isFirstTimePlayer)
        {
            if (string.IsNullOrWhiteSpace(usernameInput.text))
            {
                Debug.LogWarning("Username is empty. Please enter a username.");
                return;
            }

            // Save the entered username and set isFirstTimePlayer to false
            playerData.username = usernameInput.text;
            playerData.isFirstTimePlayer = false;

            // Save updated data
            SaveSystem.SavePlayerData(playerData);

            Debug.Log("Account created successfully with username: " + playerData.username);

            // Load the initial character selection scene
            SceneManager.LoadScene("InitialCharacter");
        }
        else
        {
            // Load the exercise type selection scene for returning users
            SceneManager.LoadScene("ExerciseTypeMenu");
        }
    }
}
