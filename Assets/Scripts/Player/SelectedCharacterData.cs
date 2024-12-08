using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCharacterData : MonoBehaviour
{
    public static Sprite SelectedGameCharacter;

    public Sprite[] availableCharacters;



    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        // Load player data to get the selected character index
        SaveSystem saveSystem = FindObjectOfType<SaveSystem>();

        PlayerData playerData = saveSystem.LoadPlayerData();

        if (playerData.selectedCharacterIndex >= 0)
        {
            // Set the static selected character sprite based on the saved index
            //InitialCharacterSelection characterSelection = FindObjectOfType<InitialCharacterSelection>();


            //SelectedGameCharacter = characterSelection.GameCharacter[playerData.selectedCharacterIndex];
            SelectedGameCharacter = availableCharacters[playerData.selectedCharacterIndex];

        }
        else
        {
            Debug.LogWarning("No valid character");
        }
    }
}


   
      




    
