using UnityEngine;

public class WorkoutDataManager : MonoBehaviour
{
    public ProfileManager profileManager;
    private WorkoutSession currentWorkout;

    public void StartWorkout(string exerciseType, int intensity)
    {
        currentWorkout = new WorkoutSession
        {
            exerciseType = exerciseType,
            intensity = intensity,
            duration = 0f,
            sessionDate = System.DateTime.Now,
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
