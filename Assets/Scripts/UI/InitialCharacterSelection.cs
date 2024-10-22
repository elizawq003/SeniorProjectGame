using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialCharacterSelection : MonoBehaviour
{
    //selected character
    public Image selectedCharacter;

    //array of all characters
    public Image[] allCharacters;

    //if a characters is clicked, select the character
    public void onCharacterClicked(int index)
    {
        selectedCharacter.sprite = allCharacters[index].sprite;
    }

}
