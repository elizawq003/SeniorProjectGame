using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCharacterData : MonoBehaviour
{
    public static Sprite SelectedGameCharacter;

    public Sprite[] GameCharacter;

    private void Start()
    {
        PlayerData playerData = SaveSystem.LoadPlayerData();

        if (playerData.selectedCharacterIndex >= 0)
        {
            // Use the singleton instance to get the selected character sprite
            SelectedGameCharacter = InitialCharacterSelection.Instance.GameCharacter[
                playerData.selectedCharacterIndex
            ];
        }
    }
}
