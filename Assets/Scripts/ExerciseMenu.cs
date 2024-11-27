using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // For scene switching

public class ExerciseMenu : MonoBehaviour
{
    public TMP_Dropdown exerciseDropdown;   // Dropdown for exercise type
    public TMP_Dropdown intensityDropdown;  // Dropdown for intensity level
    public GameObject submitButton;         // Reference to Submit button

    // Called when the user clicks the submit button
    public void OnSubmit()
    {
        // Get the selected options from the dropdowns
        string selectedExercise = exerciseDropdown.options[exerciseDropdown.value].text;
        string selectedIntensity = intensityDropdown.options[intensityDropdown.value].text;

        // Save the data to WorkoutDataManager
        WorkoutDataManager.Instance.selectedExercise = selectedExercise;
        WorkoutDataManager.Instance.selectedIntensity = selectedIntensity;

        // Load the next scene (e.g., WorkoutScene)
        SceneManager.LoadScene("WorkoutScene");
    }
}
