using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenuController : MonoBehaviour
{
    //load the workout scene
    public void StartGame()
    {


        /*
        //load the main game scene
        SceneManager.LoadScene("ExerciseTypeMenu");
        
        //load the initial character selection scene
        SceneManager.LoadScene("InitialCharacter");
        */
        //load the log in  scene
        SceneManager.LoadScene("LogInScene");
    }

    /*
    //select the initial character
    public void InitialCharacter()
    {


        //load the initial character selection scene
        SceneManager.LoadScene("InitialCharacter");


    }*/



    //Exit game
    public void ExitGame()
    {
        
        Application.Quit();
    }

}
