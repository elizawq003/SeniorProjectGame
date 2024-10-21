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

    //load the customize character scene
    public void Customize()
    {


        //load the main game scene
        SceneManager.LoadScene("Customize");


    }



    //Exit game
    public void ExitGame()
    {
        
        Application.Quit();
    }

}
