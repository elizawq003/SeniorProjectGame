using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterStorage : MonoBehaviour
{
    /*
     * show all unlocked characters
     * select character for future use
     * 
     */

    public PlayerData playerData;

    public SaveSystem saveSystem;

    public Image[] characterImages;

    public Sprite[] characterSprites;

    private int selectedCharacterIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        // Load player data and save system
        saveSystem = FindObjectOfType<SaveSystem>();

        playerData = saveSystem.LoadPlayerData();

        updateStoragePanel();
    }

    private void updateStoragePanel()
    {
        for (int i = 0; i < characterImages.Length; i++)
        {
            //set sprite for each character image
            characterImages[i].sprite = characterSprites[i];

            //If the character is unlocked, set it to interactable
            if (playerData.unlockedCharacters[i])
            {
                characterImages[i].color = Color.white;
                characterSelection(i);

            }
            else
            {
                //If the character is locked, disable interaction and gray out
                characterImages[i].color = new Color(1f, 1f, 1f, 0.5f);
            }

        }
    }

    public void characterSelection(int index)
    {

        //add dynamic button for each character so that it can be selected
        Button characterButton = characterImages[index].GetComponent<Button>();

        if (characterButton == null)
        {
            characterButton = characterImages[index].gameObject.AddComponent<Button>();
        }

        characterButton.onClick.RemoveAllListeners();

        characterButton.onClick.AddListener(() => selectedCharacter(index));
    }


    public void selectedCharacter(int index)
    {
        if (selectedCharacterIndex != -1)
        {
            // Remove highlight from the previously selected character
            characterImages[selectedCharacterIndex].color = Color.white; 
        }

        // Highlight the newly selected character
        characterImages[index].color = Color.blue;

        //Update the selected character index
        selectedCharacterIndex = index;

        playerData.selectedCharacterIndex = index;

        saveSystem.SavePlayerData(playerData);

        Debug.Log($"Character {index} selected!");
    }


}
