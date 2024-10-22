using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialCustomizeController : MonoBehaviour
{
    //load the workout scene
    public void WorkOut()
    {


        //load the main game scene
        SceneManager.LoadScene("TimedWorkOut");


    }

}
