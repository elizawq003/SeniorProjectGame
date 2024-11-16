using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeletedPetData : MonoBehaviour
{
    public static Sprite Selectedpet;

    public Sprite[] availablePets;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        // Load player data to get the selected character index
        SaveSystem saveSystem = FindObjectOfType<SaveSystem>();

        PlayerData playerData = saveSystem.LoadPlayerData();

        if (playerData.seletcedPetIndex >= 0)
        {
            // Set the static selected character sprite based on the saved index
            //InitialCharacterSelection characterSelection = FindObjectOfType<InitialCharacterSelection>();


            //SelectedGameCharacter = characterSelection.GameCharacter[playerData.selectedCharacterIndex];
            Selectedpet = availablePets[playerData.seletcedPetIndex];

        }
        else
        {
            Debug.LogWarning("No valid pet");
        }
    }
}
