using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LogInSceneController : MonoBehaviour
{
    //private SaveSystem saveSystem;

    private PlayerData playerData;

    public TMP_Text welcomeText;

    public Button Button;

    public TMP_InputField usernameInput;

    [SerializeField] private SaveSystem saveSystem;


    // Start is called before the first frame update
    private void Start()
    {
        /*
        // Initialize the SaveSystem
        saveSystem = new SaveSystem();
        */
        

            // Load player data to determine if this is a first-time user
            playerData = saveSystem.LoadPlayerData();

        // Check if this is a first-time user
        if (playerData.isFirstTimePlayer)
        {
            //if first-time user show welcome message and set username
            welcomeText.text = "Welcome! Please create an account.";

            // Enable the username input field for first-time users
            usernameInput.gameObject.SetActive(true);
            
        }

        else
        {
            //if not first timer user show welcome back message
            welcomeText.text = "Welcome back!";

            // Disable the username input field for returning users
            usernameInput.gameObject.SetActive(false);
        }

    }

    public void OnContinueButtonClicked()
    {
        // For first-time users, save the entered username
        if (playerData.isFirstTimePlayer)
        {
            if (string.IsNullOrWhiteSpace(usernameInput.text))
            {
                Debug.LogWarning("Username is empty. Please enter a username.");

                return; // Exit if username is empty
            }


            // Save the entered username and set isFirstTimePlayer to false
            playerData.username = usernameInput.text;

            playerData.isFirstTimePlayer = false;

            // Save updated data
            saveSystem.SavePlayerData(playerData);

            Debug.Log("Account created successfully with username: " + playerData.username);


            //load the initial character selection scene
            SceneManager.LoadScene("InitialCharacter");
        }

        else
        {
            //load the exercise type  selection scene for returning users
            SceneManager.LoadScene("ExerciseTypeMenu");
        }


    }



}
