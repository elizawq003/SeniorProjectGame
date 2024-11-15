using System;
using TMPro;
using UnityEngine;

public class WorkoutDataManager : MonoBehaviour
{
    public static WorkoutDataManager Instance { get; private set; }
    public ProfileManager profileManager;
    private WorkoutSession currentWorkout;

    public string selectedExercise;
    public string selectedIntensity;

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

        currentWorkout = new WorkoutSession
        {
            exerciseType = selectedExercise,
            intensity = intensityToInt,
            duration = 0f,
            sessionDate = DateTime.Now,
        };
    }

    public void UpdateWorkoutDuration(float deltaTime)
    {
        if (currentWorkout != null)
        {
            currentWorkout.duration += deltaTime;
        }
    }

    public void EndWorkout(int caloriesBurned)
    {
        if (currentWorkout != null)
        {
            currentWorkout.caloriesBurned = caloriesBurned;
            profileManager.AddWorkoutSession(currentWorkout);
            profileManager.UpdateCurrency(caloriesBurned); // Reward currency based on calories burned
            currentWorkout = null;
        }
    }
}
