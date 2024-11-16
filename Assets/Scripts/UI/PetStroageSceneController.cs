using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PetStroageSceneController : MonoBehaviour
{
    //load the shop scene
    public void toShopScene()
    {
        //load the shop scene
        SceneManager.LoadScene("ShopScene");
    }

    //load the character storage scene
    public void toCharacterStorage()
    {
        //load the exercise selection type scene
        SceneManager.LoadScene("CharacterStorage");
    }

    //load the exercise type scene
    public void toExercise()
    {
        //load the exercise selection type scene
        SceneManager.LoadScene("ExerciseTypeMenu");
    }
}
