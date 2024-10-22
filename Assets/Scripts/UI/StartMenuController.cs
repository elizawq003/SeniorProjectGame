using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    //load the workout scene
    public void Start()
    {
        //load the main game scene
        SceneManager.LoadScene("TimedWorkOut");
    }

    //select the initial character
    public void InitialCharacter()
    {
        //load the initial character selection scene
        SceneManager.LoadScene("InitialCharacter");
    }

    //Exit game
    public void ExitGame()
    {
        Application.Quit();
    }
}
