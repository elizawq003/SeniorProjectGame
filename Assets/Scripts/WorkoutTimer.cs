using UnityEngine;
using TMPro;

public class WorkoutTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;       // To display the timer
    public TextMeshProUGUI caloriesText;    // To display calories burned
    public TMP_InputField TimerDurationInput;    // Input field for workout duration (in seconds)
    public GameObject startButton;          // Reference to Start button
    public GameObject cancelButton;         // Reference to Cancel button

    private bool isTimerRunning = false;
    private float elapsedTime = 0f;
    private float timerDuration = 0f;       // Timer duration in seconds
    private string selectedExercise;
    private string selectedIntensity;

    // Caloric burn rates (example rates in calories per minute)
    private float runningCalories = 10f;
    private float cyclingCalories = 8f;
    private float swimmingCalories = 9f;
    private float weightliftingCalories = 6f;

    void Start()
    {
        // Retrieve user data from WorkoutDataManager
        selectedExercise = WorkoutDataManager.instance.selectedExercise;
        selectedIntensity = WorkoutDataManager.instance.selectedIntensity;

        // Hide the calories text at the start
        caloriesText.gameObject.SetActive(false);
        cancelButton.SetActive(false); // Hide the cancel button initially
    }

    // Called when the user clicks the Start button
    public void StartTimer()
    {
        // Get the duration from the input field, in seconds
        if (float.TryParse(TimerDurationInput.text, out timerDuration))
        {
            isTimerRunning = true;
            elapsedTime = 0f; // Reset the elapsed time
            startButton.SetActive(false); // Hide the Start button once timer starts
            cancelButton.SetActive(true); // Show the Cancel button
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
            elapsedTime += Time.deltaTime; // Increment elapsed time
            UpdateTimerDisplay(timerDuration - elapsedTime);

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

    // Called to stop the timer when it finishes
    void StopTimer()
    {
        isTimerRunning = false;

        // Calculate and display the calories burned
        float caloriesBurned = CalculateCalories();
        DisplayCalories(caloriesBurned);

        // Show the calories text when the timer finishes
        caloriesText.gameObject.SetActive(true);

        cancelButton.SetActive(false);
        startButton.SetActive(true);
    }

    // Called when the user clicks the Cancel button
    public void CancelTimer()
    {
        isTimerRunning = false; // Stop the timer
        elapsedTime = 0f; // Reset the elapsed time
        UpdateTimerDisplay(timerDuration); // Reset the timer display
        caloriesText.gameObject.SetActive(false); // Hide calories text

        // Show the Start button again, hide the Cancel button
        startButton.SetActive(true);
        cancelButton.SetActive(false);

        Debug.Log("Timer canceled.");
    }

    float CalculateCalories()
    {
        float totalCalories = 0f;
        switch (selectedExercise)
        {
            case "Running":
                totalCalories = runningCalories * (elapsedTime / 60); // per minute
                break;
            case "Cycling":
                totalCalories = cyclingCalories * (elapsedTime / 60);
                break;
            case "Swimming":
                totalCalories = swimmingCalories * (elapsedTime / 60);
                break;
            case "Weightlifting":
                totalCalories = weightliftingCalories * (elapsedTime / 60);
                break;
        }
        return totalCalories;
    }

    void DisplayCalories(float calories)
    {
        caloriesText.text = $"Calories Burned: {calories:F2}";
    }
}
