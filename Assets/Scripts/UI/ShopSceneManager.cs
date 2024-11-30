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

    //load the pet storage scene

    public void toPetStorage()
    {
        //load the shop scene
        SceneManager.LoadScene("PetStorage");
    }


}
