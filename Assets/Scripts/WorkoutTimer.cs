using UnityEngine;
using TMPro;

public class WorkoutTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // To display the timer
    public GameObject startButton;    // Reference to the Start Button
    public GameObject cancelButton;   // Reference to the Cancel Button
    public TMP_InputField durationInput; // Input field for user to set timer duration

    private bool isTimerRunning = false;
    private float elapsedTime = 0f;
    private float timerDuration = 0f; // Duration user sets for the timer

    // Method to start the timer
    public void StartTimer()
    {
        // Try parsing the input duration to a float
        if (float.TryParse(durationInput.text, out timerDuration) && timerDuration > 0)
        {
            isTimerRunning = true;
            elapsedTime = 0f; // Reset the elapsed time
            startButton.SetActive(false); // Hide the Start button once timer starts
            cancelButton.SetActive(true); // Show the Cancel button when timer starts
        }
        else
        {
            Debug.LogWarning("Please enter a valid duration (in seconds).");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime; // Increment the elapsed time
            UpdateTimerDisplay(timerDuration - elapsedTime);

            // Stop the timer once the duration is reached
            if (elapsedTime >= timerDuration)
            {
                isTimerRunning = false;
                Debug.Log("Timer has finished.");
                cancelButton.SetActive(false); // Hide the Cancel button when the timer finishes
                startButton.SetActive(true);   // Show the Start button again when the timer finishes
            }
        }
    }

    // Method to update the timer UI text
    void UpdateTimerDisplay(float timeToDisplay)
    {
        if (timeToDisplay < 0) timeToDisplay = 0; // Avoid negative time

        int minutes = Mathf.FloorToInt(timeToDisplay / 60); // Calculate minutes
        int seconds = Mathf.FloorToInt(timeToDisplay % 60); // Calculate seconds

        // Update the timer text in "mm:ss" format
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Method to stop the timer when the Cancel button is clicked
    public void CancelTimer()
    {
        isTimerRunning = false; // Stop the timer
        cancelButton.SetActive(false); // Hide the Cancel button
        startButton.SetActive(true);   // Show the Start button again
        UpdateTimerDisplay(0); // Reset the display to "00:00"
        Debug.Log("Timer has been cancelled.");
    }
}
