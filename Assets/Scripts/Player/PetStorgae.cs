using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PetStorgae : MonoBehaviour
{
    /*
     * show all unlocked pets
     * select pets for future use
     * 
     */

    public PlayerData playerData;

    public SaveSystem saveSystem;

    public Image[] petImages;

    public Sprite[] petSprites;

    private int seletcedPetIndex = -1;


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
        for (int i = 0; i < petImages.Length; i++)
        {
            //set sprite for each pet image
            petImages[i].sprite = petSprites[i];

            //If the pet is unlocked, set it to interactable
            if (playerData.unlockedCharacters[i])
            {
               petImages[i].color = Color.white;
                petSelection(i);

            }
            else
            {
                //If the pet is locked, disable interaction and gray out
                petImages[i].color = new Color(1f, 1f, 1f, 0.5f);
            }

        }
    }

    public void petSelection(int index)
    {

        //add dynamic button for each pet so that it can be selected
        Button petButton = petImages[index].GetComponent<Button>();

        if (petButton == null)
        {
            petButton = petImages[index].gameObject.AddComponent<Button>();
        }

        petButton.onClick.RemoveAllListeners();

        petButton.onClick.AddListener(() => selectedCharacter(index));
    }

    public void selectedCharacter(int index)
    {
        if (seletcedPetIndex != -1)
        {
            // Remove highlight from the previously selected character
            petImages[seletcedPetIndex].color = Color.white;
        }

        // Highlight the newly selected character
        petImages[index].color = Color.blue;

        //Update the selected character index
        seletcedPetIndex = index;

        playerData.selectedCharacterIndex = index;

        saveSystem.SavePlayerData(playerData);

        Debug.Log($"Character {index} selected!");
    }

}
