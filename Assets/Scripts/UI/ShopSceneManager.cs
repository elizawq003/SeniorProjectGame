using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopSceneManager : MonoBehaviour
{ 

    //load the character storage scene
    public void toCharacterStorage()
    {
        //load the exercise selection type scene
        SceneManager.LoadScene("CharacterStorage");
    }

}
