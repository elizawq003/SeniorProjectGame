using UnityEngine;
using TMPro;

public class WorkoutTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;       // To display the timer
    public TextMeshProUGUI caloriesText;    // To display calories burned
    public TMP_InputField TimerDurationInput;    // Input field for workout duration
    public GameObject startButton;          // Reference to Start button
    public GameObject cancelButton;         // Reference to Cancel button

    private bool isTimerRunning = false;
    private float elapsedTime = 0f;
    private float timerDuration = 0f;       // Duration from user input
    private string selectedExercise;
    private string selectedIntensity;

    private float runningCalories = 10f;
    private float cyclingCalories = 8f;
    private float swimmingCalories = 9f;
    private float weightliftingCalories = 6f;

    void Start()
    {
        // Retrieve user data from WorkoutDataManager
        selectedExercise = WorkoutDataManager.instance.selectedExercise;
        selectedIntensity = WorkoutDataManager.instance.selectedIntensity;
    }

    // Called when the user clicks the Start button
    public void StartTimer()
    {
        // Get the duration from the input field
        if (float.TryParse(TimerDurationInput.text, out timerDuration))
        {
            timerDuration *= 60; // Convert minutes to seconds
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
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay(timerDuration - elapsedTime);

            if (elapsedTime >= timerDuration)
            {
                isTimerRunning = false;
                float caloriesBurned = CalculateCalories();
                DisplayCalories(caloriesBurned);
                cancelButton.SetActive(false);
                startButton.SetActive(true);
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

    float CalculateCalories()
    {
        float totalCalories = 0f;
        switch (selectedExercise)
        {
            case "Running":
                totalCalories = runningCalories * (elapsedTime / 60);
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
