using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterStorageSceneController : MonoBehaviour
{
    //load the shop scene
    public void toShopScene()
    {
        //load the shop scene
        SceneManager.LoadScene("ShopScene");
    }

    //load the exercise type scene
    public void toExercise()
    {
        //load the exercise selection type scene
        SceneManager.LoadScene("ExerciseTypeMenu");
    }

}
