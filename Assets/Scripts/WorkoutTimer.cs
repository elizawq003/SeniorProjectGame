using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class WorkoutTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;       // To display the timer
    public TextMeshProUGUI caloriesText;    // To display calories burned

    public TextMeshProUGUI highestCaloriesText;   // Highest calories burnt display
    public TextMeshProUGUI longestWorkoutText;    // Longest workout display

    //display coins eared
    public TextMeshProUGUI totalCoinText;
    public TextMeshProUGUI earnedCoinText;

    public TMP_InputField TimerDurationInput;    // Input field for workout duration (in seconds)
    public GameObject startButton;          // Reference to Start button
    public GameObject cancelButton;         // Reference to Cancel button
    public GameObject StorageButton;
    public GameObject ShopButton;


    private bool isTimerRunning = false;
    private float elapsedTime = 0f;
    private float timerDuration = 0f;       // Timer duration in seconds
    private int caloriesBurned = 0;
    private float coinsEarned = 0;

    private SaveSystem saveSystem;
    private GameManager gameManager;
    private PlayerData playerData;

    //private string selectedExercise;

    //private string selectedIntensity;

    // Calories burned in this session



    /*
    // Caloric burn rates (example rates in calories per minute)
    private float runningCalories = 10f;
    private float cyclingCalories = 8f;
    private float swimmingCalories = 9f;
    private float weightliftingCalories = 6f;
    */

    void Start()
    {
        saveSystem = SaveSystem.Instance;

        // Load player data 
        playerData = saveSystem.LoadPlayerData();

        gameManager = GameManager.Instance;

        /*
        // Retrieve user data from WorkoutDataManager
        selectedExercise = WorkoutDataManager.instance.selectedExercise;
        selectedIntensity = WorkoutDataManager.instance.selectedIntensity;
        */


        // Hide the calories text at the start
        //Hide the coins text at the start
        //caloriesText.gameObject.SetActive(false);
        totalCoinText.gameObject.SetActive(false);
        earnedCoinText.gameObject.SetActive(false);
        cancelButton.SetActive(false); // Hide the cancel button initially


        // Update records in the UI
        UpdateRecordsDisplay();
        //UpdateTotalCoinsDisplay();

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
            StorageButton.SetActive(true);
            ShopButton.SetActive(true);
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

        /*
        // Calculate and display the calories burned
        float caloriesBurned = CalculateCalories();
        DisplayCalories(caloriesBurned);
        */

        caloriesBurned = Mathf.FloorToInt(timerDuration / 10); //1 calorie per 10 seconds
        // Display calories burned
        caloriesText.text = $"Calories Burned: {caloriesBurned}";

        //convert calories to coins
        coinsEarned = CaloriesToCoins(caloriesBurned);
        UpdateCoins(coinsEarned);
        DisplayTotalCoins();
        DisplayEarnedCoins(coinsEarned);

        // Add the session to the player's profile
        WorkoutSession session = new WorkoutSession("Running", 2, elapsedTime, caloriesBurned, System.DateTime.Now);
        GameManager.Instance.AddWorkoutSession(session);

        // Update the records display
        UpdateRecordsDisplay();

        // Show the calories text when the timer finishes
        //Show the earned coins and total coins text when the timer finishes
        //caloriesText.gameObject.SetActive(true);
        totalCoinText.gameObject.SetActive(true);
        earnedCoinText.gameObject.SetActive(true);

        cancelButton.SetActive(false);
        startButton.SetActive(true);
        StorageButton.SetActive(true);
        ShopButton.SetActive(true);

        
    }

    

    // Called when the user clicks the Cancel button
    public void CancelTimer()
    {
        isTimerRunning = false; // Stop the timer
        elapsedTime = 0f; // Reset the elapsed time
        UpdateTimerDisplay(timerDuration); // Reset the timer display
        caloriesText.gameObject.SetActive(false); // Hide calories text
        totalCoinText.gameObject.SetActive(false);
        earnedCoinText.gameObject.SetActive(false);

        // Show the Start button again, hide the Cancel button
        startButton.SetActive(true);
        cancelButton.SetActive(false);
        StorageButton.SetActive(true);
        ShopButton.SetActive(true);

        Debug.Log("Timer canceled.");
    }

    /*
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
    }*/

    /*
    void DisplayCalories(float calories)
    {
        caloriesText.text = $"Calories Burned: {calories:F2}";
    }*/

    public void UpdateRecordsDisplay()
    {
        if (playerData != null)
        {
            highestCaloriesText.text = $"Highest Calories Burnt: {playerData.highestCaloriesBurnt}";
            longestWorkoutText.text = $"Longest Workout: {playerData.longestWorkoutDuration / 60:F2} minutes";
        }
        else
        {
            Debug.LogError("PlayerData is null.");
        }
    }

    public float CaloriesToCoins(float calories)
    {
        /*
        //1 coin = 10 calories
        int conversionRate = 10;

        return Mathf.FloorToInt(calories / conversionRate);
        */
        //1 coin = 1 calories
        return Mathf.FloorToInt(calories);

    }

    public void UpdateCoins(float coinsEarned)
    {
        /*
        //load player data
        PlayerData playerData = saveSystem.LoadPlayerData();
        */
        if (gameManager != null)
        {
            playerData = gameManager.GetPlayerData();

            //update coins
            playerData.coins += (int)coinsEarned;

            //save the update coin data
            saveSystem.SavePlayerData(playerData);

            Debug.Log("Coins Earned: " + coinsEarned);
            Debug.Log("Total Coins: " + playerData.coins);

            totalCoinText.text = $"Total Coins: {playerData.coins}";
        }

        else
        {
            Debug.LogError("GameManager is not initialized.");
        }

    }

    /*
    public void UpdateTotalCoinsDisplay()
    {
        if (playerData != null)
        {
            totalCoinText.text = $"Total Coins: {playerData.coins}";
        }
    }
    */
    
    public void DisplayTotalCoins()
    {
        PlayerData playerData = saveSystem.LoadPlayerData();

        totalCoinText.text = $"Total Coins: {playerData.coins}";
    }

    public void DisplayEarnedCoins(float coinsEarned)
    {
        earnedCoinText.text = $"Coins Earned: {coinsEarned}";
    }

    

    //load the character storage scene
    public void toCharacterStorage()
    {
        

        //load the exercise selection type scene
        SceneManager.LoadScene("CharacterStorage");
    }

    //load the shop scene
    public void toShopScene()
    {
        //load the shop scene
        SceneManager.LoadScene("ShopScene");
    }


}
