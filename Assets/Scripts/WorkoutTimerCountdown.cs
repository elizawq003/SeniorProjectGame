/*using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkoutTimerCountdown : MonoBehaviour
{
    // This Class will serve as the setter of our timer in  a workout
    //The Main menu should call upon this script before loading into a scene to set the timer at the desired value
    //It will take seconds so when calling it with minutes, do (minute amount) * 60

    //time left in the timer
    public float timeLeft;
    //This will be used to allow us to freeze the timer
    public bool timerActive = false;

    public TextMeshProUGUI timerText;

    void Start()
    {
        //Begin clock at start
        timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if timer activated
        if (timerActive)
        {
            //if timer is not at 0 yet
            if(timeLeft> 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimerDisplay(timeLeft);
            }
            else
            {
                timeLeft = 0;
                timerActive = false;
                Debug.Log("timer should now have hit 0");
            }
        }
    }

    //Call in Reference to a pause button or when workout is canceled
    public void StopTimer()
    {
        timerActive = false;
    }

    //use this from main menu to set the timer to the desired time
    public void SetInitialTimer(float initialTime)
    {
        timeLeft = initialTime;
    }

    //This will be used for the timer display so it shows accurately in seconds
    void UpdateTimerDisplay(float currentTime)
    {
        //Done as it will round down for these functions
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        //set the text on the timer text object to this current time
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
*/