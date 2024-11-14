using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // For scene switching

public class ExerciseMenu : MonoBehaviour
{
    public TMP_Dropdown exerciseDropdown; // Dropdown for exercise type
    public TMP_Dropdown intensityDropdown; // Dropdown for intensity level
    public GameObject submitButton; // Reference to Submit button

    private void Start()
    {
        // Check if WorkoutDataManager.Instance is set, for error handling
        if (WorkoutDataManager.Instance == null)
        {
            Debug.LogError("WorkoutDataManager instance not found in the scene.");
        }
    }

    // Called when the user clicks the submit button
    public void OnSubmit()
    {
        if (WorkoutDataManager.Instance == null)
            return;

        // get selected options from
        string selectedExercise = exerciseDropdown.options[exerciseDropdown.value].text;
        string selectedIntensity = intensityDropdown.options[intensityDropdown.value].text;

        // Save the data to WorkoutDataManager
        WorkoutDataManager.Instance.selectedExercise = selectedExercise;
        WorkoutDataManager.Instance.selectedIntensity = selectedIntensity;

        // Load the next scene (e.g., WorkoutScene)
        SceneManager.LoadScene("WorkoutScene");
    }
}
