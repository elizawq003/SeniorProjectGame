namespace SeniorProjectGame.Assets.Scripts
{
    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public int userPoints = 0;
        public string username = "";

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject); // Keeps this object across scenes
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void AddPoints(int points)
        {
            userPoints += points;
        }

        public void SetUsername(string name)
        {
            username = name;
        }
    }
}
