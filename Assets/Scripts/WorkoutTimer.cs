using UnityEngine;
using TMPro;

public class WorkoutTimer : MonoBehaviour
{
    public TMP_Text timerText;         // To display the countdown timer
    public TMP_Text caloriesText;     // To display calories burned
    public TMP_Text highestCaloriesText; // Highest calories burnt display
    public TMP_Text longestWorkoutText;  // Longest workout display

    public TMP_InputField TimerDurationInput; // Duration input
    public GameObject startButton;      // Start button
    public GameObject cancelButton;     // Cancel button

    private bool isTimerRunning = false;
    private float elapsedTime = 0f;
    private float timerDuration = 0f;
    private int caloriesBurned = 0;     // Example calories burned (calculation logic not included)

    void Start()
    {
        // Hide the cancel button initially
        cancelButton.SetActive(false);

        // Update UI with current records at the start
        UpdateRecordsDisplay();
    }

    public void StartTimer()
    {
        if (float.TryParse(TimerDurationInput.text, out timerDuration))
        {
            isTimerRunning = true;
            elapsedTime = 0f; // Reset elapsed time
            startButton.SetActive(false);
            cancelButton.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Please enter a valid duration.");
        }
    }

    void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;

            // Update the timer display
            UpdateTimerDisplay(timerDuration - elapsedTime);

            // Check if the timer has reached its end
            if (elapsedTime >= timerDuration)
            {
                StopTimer();
            }
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        if (timeToDisplay < 0) timeToDisplay = 0;
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void StopTimer()
    {
        isTimerRunning = false;

        // Example calories burned calculation (replace with your logic)
        caloriesBurned = Mathf.FloorToInt(timerDuration / 10); // Example: 1 calorie per 10 seconds

        // Display calories burned
        caloriesText.text = $"Calories Burned: {caloriesBurned}";

        // Add the session to the player's profile
        WorkoutSession session = new WorkoutSession("Running", 2, elapsedTime, caloriesBurned, System.DateTime.Now);
        ProfileManager.Instance.AddWorkoutSession(session);

        // Save the updated profile
        ProfileManager.Instance.SaveProfile();

        // Update the records display
        UpdateRecordsDisplay();

        // Reset UI buttons
        startButton.SetActive(true);
        cancelButton.SetActive(false);
    }

    public void UpdateRecordsDisplay()
    {
        // Ensure ProfileManager and PlayerData exist
        if (ProfileManager.Instance != null && ProfileManager.Instance.playerData != null)
        {
            highestCaloriesText.text = $"Highest Calories Burnt: {ProfileManager.Instance.playerData.highestCaloriesBurnt}";
            longestWorkoutText.text = $"Longest Workout: {ProfileManager.Instance.playerData.longestWorkoutDuration / 60:F2} minutes";
        }
        else
        {
            Debug.LogError("ProfileManager or PlayerData is null.");
        }
    }
}
