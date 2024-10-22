namespace SeniorProjectGame.Assets.Scripts
{
    using UnityEngine;
    using UnityEngine.UI;

    public class ProfileManager : MonoBehaviour
    {
        public Text usernameText;

        void Start()
        {
            LoadProfile();
        }

        void LoadProfile()
        {
            string savedUsername = PlayerPrefs.GetString("Username", "New User");
            usernameText.text = "Welcome, " + savedUsername;
        }
    }
}
