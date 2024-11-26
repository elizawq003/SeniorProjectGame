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

    private SaveSystem saveSystem;

    private void Start()
    {
        // Load player data and save system
        saveSystem = FindObjectOfType<SaveSystem>();

        playerData = saveSystem.LoadPlayerData();
    }

    //if a characters is clicked, select the character
    public void onCharacterClicked(int index)
    {
        // Update the selected character sprite
        selectedCharacter.sprite = allCharacters[index].sprite;

        // Store the selected character's index in PlayerData
        playerData.selectedCharacterIndex = index;

        //mark the selected character as unlocked
        for (int i = 0; i < playerData.unlockedCharacters.Length; i++)
        {
            // Reset all other characters
            playerData.unlockedCharacters[i] = false;
        }

        //mark the selected one as unlocked
        playerData.unlockedCharacters[index] = true;

        //store the selected characterdata
        SelectedCharacterData.SelectedGameCharacter = GameCharacter[index];

        // Save updated player data
        saveSystem.SavePlayerData(playerData);


    }

}
