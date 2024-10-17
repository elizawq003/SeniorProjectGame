using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartExercise()
    {
        SceneManager.LoadScene("ExerciseScene"); // just called it this because I did not know what the scene name is
    }

    public void OpenProfile()
    {
        SceneManager.LoadScene("ProfileScene"); // just called it this because I did not know what the scene name is
    }

    public void ViewProgressReport()
    {
        SceneManager.LoadScene("ProgressReportScene"); // just called it this because I did not know what the scene name is
    }

    public void OpenStore()
    {
        SceneManager.LoadScene("StoreScene"); // just called it this because I did not know what the scene name is
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("SettingsScene"); // just called it this because I did not know what the scene name is
    }

    public void QuitApp()
    {
        Application.Quit(); // just called it this because I did not know what the scene name is
    }
}
