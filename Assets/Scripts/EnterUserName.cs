namespace SeniorProjectGame.Assets.Scripts
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class EnterUserNameManager : Monobehaviour
    {
        public InputField usernameInputField;
        public Button confirmButton;
        public Text messageText;

        void Start()
        {
            confirmButton.onClick.AddListener(SaveUsername);
        }

        void SaveUsername()
        {
            string enteredUsername = usernameInputField.text;
            if (!string.IsNullOrEmpty(enteredUsername))
            {
                PlayerPrefs.SetString("Username", enteredUsername);
                PlayerPrefs.Save();
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                messageText.text = "Please enter a valid username!";
            }
        }
    }
}
