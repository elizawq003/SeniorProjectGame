using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialCustomizeController : MonoBehaviour
{
    //load the workout scene
    public void WorkOut()
    {


        //load the exercise selection type scene
        SceneManager.LoadScene("ExerciseTypeMenu");


    }

    /*
    //load the character storage scene
    public void toCharacterStorage()
    {
        //load the exercise selection type scene
        SceneManager.LoadScene("CharacterStorage");
    }*/
}
