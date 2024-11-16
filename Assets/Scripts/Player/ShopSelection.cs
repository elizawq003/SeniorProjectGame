using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSelection : MonoBehaviour
{
    //have price labeled under each character

    /*
     * click:
     * -1. enough money ask if purchase
     *  - a. purchase -> store in unlocked characters scene and data
     *  - b. else -> can exit the interactive panel
     * - 2. not enough money -> different panel (can't purchase
     */

    public PlayerData playerData;

    public SaveSystem saveSystem;

    public TextMeshProUGUI coinText;

    //For character
    //button attached
    public Button[] characterButtons;
    //price tags
    public TextMeshProUGUI[] characterPriceTags;
    //actual price
    public float[] characterPrices;

    //for pet
    //button attached
    public Button[] petButtons;
    //price tags
    public TextMeshProUGUI[] petPriceTags;
    //actual price
    public float[] petPrices;

    //UIs in the scene
    public GameObject purchasePanel;
    public TextMeshProUGUI purchasePanelText;

    public GameObject notEnoughCoinsPanel;

    public GameObject alreadyUnlockedPanel;

    //track the selected character/pet
    private int selectedIndex;

    //track if the seletced is character
    private bool isCharacter = true;

    // Start is called before the first frame update
    void Start()
    {
        // Load player data and save system
        saveSystem = FindObjectOfType<SaveSystem>();

        playerData = saveSystem.LoadPlayerData();

        UpdateCoins();
    }

    //when a character is clicked
    public void onCharacterButtonClicked(int index)
    {
        selectedIndex = index;

        isCharacter = true;

        onButtonClickControl(characterPrices[index], playerData.unlockedCharacters[index]);
    }


    //when a pet is clicked
    public void onPetButtonClicked(int index)
    {
        selectedIndex = index;

        isCharacter = false;

        onButtonClickControl(petPrices[index], playerData.unlockedPets[index]);
    }

    /* when a charater/pet is clicked, check if the character is unlocked or no,
     * if it's been unlocked -> "already unlocked".
     * if not purchase panel/notenoughCoins panel.
     * 
     */
    public void onButtonClickControl(float price, bool isUnlocked)
    {
        if (isUnlocked)
        {
            alreadyUnlockedPanel.SetActive(true);
            return;
           
        }

        if(playerData.coins >= price)
        {
            //can continue to purchase panel
            purchasePanel.SetActive(true);
            purchasePanelText.text = $"Purchase for {price} coins?";
        }
        else
        {
            //no enough coins, show notEnoughCoinsPanel
            notEnoughCoinsPanel.SetActive(true);
        }
    }

    public void purchaseItem()
    {
        //check if item is seletced
        if (selectedIndex == -1) return;

        //if successfully purchased item, deduct the coins amount in player data and unlock the item
        if (isCharacter)
        {
            playerData.coins -= (int)characterPrices[selectedIndex];

            playerData.unlockedCharacters[selectedIndex] = true;
        }
        else
        {
            //same for pets
            playerData.coins -= (int)petPrices[selectedIndex];

            playerData.unlockedPets[selectedIndex] = true;
        }

        saveSystem.SavePlayerData(playerData);

        //update the coins text
        UpdateCoins();

        purchasePanel.SetActive(false);
    }

    public void ExitPurchasePanel()
    {
        purchasePanel.SetActive(false);
    }

    public void ExitNoEnoughCoinsPanel()
    {
        notEnoughCoinsPanel.SetActive(false);
    }

    public void ExitUnlockedPanel()
    {
        alreadyUnlockedPanel.SetActive(false);
    }

    private void UpdateCoins()
    {
        coinText.text = $"Coins: {playerData.coins}";
    }
}
