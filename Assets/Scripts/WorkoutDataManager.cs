using UnityEngine;

public class WorkoutDataManager : MonoBehaviour
{
    public static WorkoutDataManager instance;

    // Variables to store the user's choices
    public string selectedExercise;
    public string selectedIntensity;
    public float workoutDuration; // In seconds

    void Awake()
    {
        // Singleton pattern to persist data between scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevent this GameObject from being destroyed when loading new scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
