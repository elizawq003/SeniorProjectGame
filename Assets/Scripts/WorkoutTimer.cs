using UnityEngine;
using TMPro;

public class WorkoutTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // To display the timer
    public GameObject startButton;    // Reference to the Start Button

    private bool isTimerRunning = false;
    private float elapsedTime = 0f;

    // This method will be called when the user clicks the Start button
    public void StartTimer()
    {
        isTimerRunning = true;
        startButton.SetActive(false); // Hide the Start button once timer starts
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime; // Increment the elapsed time
            UpdateTimerDisplay(elapsedTime);
        }
    }

    // Method to update the timer UI text
    void UpdateTimerDisplay(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60); // Calculate minutes
        int seconds = Mathf.FloorToInt(timeToDisplay % 60); // Calculate seconds

        // Update the timer text in "mm:ss" format
        timerText.text = string.Format("{00:00}:{01:00}", minutes, seconds);
    }
}
