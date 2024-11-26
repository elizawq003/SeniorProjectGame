using System;
using UnityEngine;

public class WorkoutDataManager : MonoBehaviour
{
    // Singleton instance for global access
    public static WorkoutDataManager Instance { get; private set; }

    public ProfileManager profileManager; // Reference to manage player profiles
    private WorkoutSession currentWorkout; // Tracks the current workout session

    public string selectedExercise; // Selected exercise type
    public string selectedIntensity; // Selected intensity level (string)

    void Awake()
    {
        // Singleton pattern to ensure a single instance of WorkoutDataManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    public void StartWorkout()
    {
        // Convert intensity from string to integer
        if (!int.TryParse(selectedIntensity, out int intensityToInt))
        {
            Debug.LogError("Invalid intensity value.");
            return;
        }

        if (string.IsNullOrEmpty(selectedExercise))
        {
            Debug.LogError("Selected exercise is not set.");
            return;
        }

        // Explicitly call the constructor with all required arguments
        currentWorkout = new WorkoutSession(
            selectedExercise, // Exercise type
            intensityToInt,   // Intensity
            0f,               // Duration (start at 0)
            0,                // Calories burned (start at 0)
            DateTime.Now      // Current date/time
        );

        Debug.Log($"Workout started: {selectedExercise} at intensity {intensityToInt}");
    }

    // Updates the workout duration
    public void UpdateWorkoutDuration(float deltaTime)
    {
        if (currentWorkout != null)
        {
            currentWorkout.duration += deltaTime; // Increment duration
        }
    }

    // Ends the workout session and saves it
    public void EndWorkout(int caloriesBurnt)
    {
        if (currentWorkout != null)
        {
            currentWorkout.caloriesBurned = caloriesBurnt;

            // Add the workout session to the player's profile
            profileManager.AddWorkoutSession(currentWorkout);

            // Update highest calories burnt if this session beats the record
            if (caloriesBurnt > profileManager.playerData.highestCaloriesBurnt)
            {
                profileManager.playerData.highestCaloriesBurnt = caloriesBurnt;
                Debug.Log($"New record! Highest calories burnt: {caloriesBurnt}");
            }

            // Update longest workout duration if this session beats the record
            if (currentWorkout.duration > profileManager.playerData.longestWorkoutDuration)
            {
                profileManager.playerData.longestWorkoutDuration = currentWorkout.duration;
                Debug.Log($"New record! Longest workout duration: {currentWorkout.duration} seconds");
            }

            // Reward the player with currency based on calories burnt
            profileManager.UpdateCurrency(caloriesBurnt);

            // Save updated player data
            profileManager.SaveProfile();

            // Clear the current workout session
            currentWorkout = null;
        }
        else
        {
            Debug.LogError("No active workout session to end.");
        }
    }
}
