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

    //store selected character for game scene
    public Sprite[] GameCharacter;

    private PlayerData playerData;

    private void Start()
    {
        playerData = SaveSystem.LoadPlayerData();
    }

    //if a characters is clicked, select the character
    public void onCharacterClicked(int index)
    {
        selectedCharacter.sprite = allCharacters[index].sprite;

        // Store the selected character's index in PlayerData
        playerData.selectedCharacterIndex = index;

        //store the selected characterdata
        SelectedCharacterData.SelectedGameCharacter = GameCharacter[index];

        // Save updated player data
        SaveSystem.SavePlayerData(playerData);
    }
}
