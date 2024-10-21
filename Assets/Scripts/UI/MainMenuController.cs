using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{
    //load the workout scene
    public void WorkOut()
    {


        //load the main game scene
        SceneManager.LoadScene("WorkOut");


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
