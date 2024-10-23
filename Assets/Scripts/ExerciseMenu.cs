using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ExerciseMenu : MonoBehaviour
{
    public TMP_Dropdown exerciseDropdown;   // Dropdown for exercise type
    public TMP_Dropdown intensityDropdown;  // Dropdown for intensity level
    public GameObject submitButton;         // Reference to Submit button

    private string selectedExercise;        // Store selected exercise type
    private string selectedIntensity;       // Store selected intensity

    // Method to handle the submission
    public void OnSubmit()
    {
        // Get the selected option from the Exercise dropdown
        selectedExercise = exerciseDropdown.options[exerciseDropdown.value].text;

        // Get the selected option from the Intensity dropdown
        selectedIntensity = intensityDropdown.options[intensityDropdown.value].text;

        // Display or process the selected options
        Debug.Log($"Selected Exercise: {selectedExercise}");
        Debug.Log($"Selected Intensity: {selectedIntensity}");

        // Load the workout scene (replace "WorkoutScene" with the actual scene name)
        SceneManager.LoadScene("WorkoutScene");
    }
}
