using UnityEngine;
using System.Collections.Generic;

public class SelectedCharacter : MonoBehaviour
{
    // The sprite renderer to show the character.
    public SpriteRenderer spriteRenderer;

    //Wether the character should show the character fighting or not
    private bool isFighting;

    /*
    // A dictionary to hold the sprites for each class, skin tone, and expression.
    private Dictionary<string, Dictionary<string, Sprite[]>> classSprites;

    // Current class and skin tone settings.
    private string currentClass;
    private string currentSkinTone;

    //Wether the character should show the character fighting or not
    private bool isFighting;

    // Setting up sprites and skin tones
    public Sprite[] class1SkinTone1Sprites; // [0] = Neutral, [1] = Fighting
    public Sprite[] class1SkinTone2Sprites;
    public Sprite[] class1SkinTone3Sprites;

    public Sprite[] class2SkinTone1Sprites;
    public Sprite[] class2SkinTone2Sprites;
    public Sprite[] class2SkinTone3Sprites;

    public Sprite[] class3SkinTone1Sprites;
    public Sprite[] class3SkinTone2Sprites;
    public Sprite[] class3SkinTone3Sprites;

    public Sprite[] class4SkinTone1Sprites;
    public Sprite[] class4SkinTone2Sprites;
    public Sprite[] class4SkinTone3Sprites;

    public Sprite[] class5SkinTone1Sprites;
    public Sprite[] class5SkinTone2Sprites;
    public Sprite[] class5SkinTone3Sprites;

    public Sprite[] class6SkinTone1Sprites;
    public Sprite[] class6SkinTone2Sprites;
    public Sprite[] class6SkinTone3Sprites;

    public Sprite[] class7SkinTone1Sprites;
    public Sprite[] class7SkinTone2Sprites;
    public Sprite[] class7SkinTone3Sprites;

    public Sprite[] class8SkinTone1Sprites;
    public Sprite[] class8SkinTone2Sprites;
    public Sprite[] class8SkinTone3Sprites;
    */
    void Start()
    {
        SetSelectedCharacter();
        isFighting = false;// Start with neutral expression
    }
        /*
        // Initialize the dictionary for storing sprites
        classSprites = new Dictionary<string, Dictionary<string, Sprite[]>>();

        // Add sprites for each class
        AddClassSprites("Class1", class1SkinTone1Sprites, class1SkinTone2Sprites, class1SkinTone3Sprites);
        AddClassSprites("Class2", class2SkinTone1Sprites, class2SkinTone2Sprites, class2SkinTone3Sprites);
        AddClassSprites("Class3", class3SkinTone1Sprites, class3SkinTone2Sprites, class3SkinTone3Sprites);
        AddClassSprites("Class4", class4SkinTone1Sprites, class4SkinTone2Sprites, class4SkinTone3Sprites);
        AddClassSprites("Class5", class5SkinTone1Sprites, class5SkinTone2Sprites, class5SkinTone3Sprites);
        AddClassSprites("Class6", class6SkinTone1Sprites, class6SkinTone2Sprites, class6SkinTone3Sprites);
        AddClassSprites("Class7", class7SkinTone1Sprites, class7SkinTone2Sprites, class7SkinTone3Sprites);
        AddClassSprites("Class8", class8SkinTone1Sprites, class8SkinTone2Sprites, class8SkinTone3Sprites);

        


        //TEMPORARY, THIS SHOULD BE HANDLED IN UPDATE FROM MENU BUT PUTTING THIS IN FOR NOW
        // Set initial class and skin tone
        currentClass = "Class1";
        currentSkinTone = "Skin1";
        isFighting = false; // Start with neutral expression

        // Update the sprite when the game starts
        UpdateSprite();
    }*/

        /*
        // Helper function to add class and skin tone sprites to the dictionary
        private void AddClassSprites(string className, Sprite[] skinTone1Sprites, Sprite[] skinTone2Sprites, Sprite[] skinTone3Sprites)
    {
        classSprites[className] = new Dictionary<string, Sprite[]>();
        classSprites[className]["Skin1"] = skinTone1Sprites;
        classSprites[className]["Skin2"] = skinTone2Sprites;
        classSprites[className]["Skin3"] = skinTone3Sprites;
    }*/



/*
    // Function to change the class, should be called before run
    public void ChangeClass(string newClass)
    {
        currentClass = newClass;
        UpdateSprite();
    }

    // Function to change the skin tone, should be called before run from options
    public void ChangeSkinTone(string newSkinTone)
    {
        currentSkinTone = newSkinTone;
        UpdateSprite();
    }*/

    
    // Method to change between neutral and fighting
    //Call every few seconds
    public void SetExpressionFighting(bool fighting)
    {
        isFighting = fighting;
        //UpdateSprite();
    }
    /*

    // Update the sprite based on current settings
    private void UpdateSprite()
    {
        if (classSprites.ContainsKey(currentClass) && classSprites[currentClass].ContainsKey(currentSkinTone))
        {
            Debug.Log("Should be loading sprite");
            // If fighting, use the fighting sprite (index 1), otherwise use the neutral one (index 0)
            spriteRenderer.sprite = isFighting ? classSprites[currentClass][currentSkinTone][1] : classSprites[currentClass][currentSkinTone][0];
        }
        else
        {
            Debug.LogWarning("No sprite found for the selected class and skin tone.");
        }
    }*/

    private void SetSelectedCharacter()
    {
        if (SelectedCharacterData.SelectedGameCharacter != null)
        {
            spriteRenderer.sprite = SelectedCharacterData.SelectedGameCharacter;
        }
    }




}
