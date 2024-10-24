using UnityEngine;
using System.Collections.Generic;

public class SelectedCharacter : MonoBehaviour
{
    // The sprite renderer to show the character.
    public SpriteRenderer spriteRenderer;

    //Wether the character should show the character fighting or not
    private bool isFighting;

    //array to hold the neutral and fighting sprite for a character
    //0 is for netural and 1 is for fighting
    public Sprite[] characterSprites = new Sprite[2];

    //array to hold the fighting sprite
    public Sprite[] fightingSprites;

    //array to hold the neutral sprite
    public Sprite[] neutralSprites;

    //Dictionary to map each neutral sprite to its fighting sprite
    public Dictionary<Sprite, Sprite> spriteMap = new Dictionary<Sprite, Sprite>();

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
        isFighting = false;// Start with neutral expression

        // Create the mapping between neutral and fighting sprites
        CreateSpriteMap();


        SetSelectedCharacter();
        
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
        UpdateSprite();
    }
    

    // Update the sprite based on current settings
    private void UpdateSprite()
    {
        // If fighting, use the fighting sprite, else use the neutral one
        if (characterSprites != null && characterSprites.Length == 2)
        {
            spriteRenderer.sprite = isFighting ? characterSprites[1] : characterSprites[0];
        }
        else
        {
            Debug.LogWarning("Selected character sprites are not properly set.");
        }

        /*
        if (classSprites.ContainsKey(currentClass) && classSprites[currentClass].ContainsKey(currentSkinTone))
        {
            Debug.Log("Should be loading sprite");
            // If fighting, use the fighting sprite (index 1), otherwise use the neutral one (index 0)
            spriteRenderer.sprite = isFighting ? classSprites[currentClass][currentSkinTone][1] : classSprites[currentClass][currentSkinTone][0];
        }
        else
        {
            Debug.LogWarning("No sprite found for the selected class and skin tone.");
        }*/
    }

    
    private void SetSelectedCharacter()
    {
        //set the neutral sprite corresponds to the selected sprite
        if (SelectedCharacterData.SelectedGameCharacter != null)
        {
            
            characterSprites[0] = SelectedCharacterData.SelectedGameCharacter;

            

            //find the corresponding fighting sprite
            if(spriteMap.TryGetValue(characterSprites[0], out Sprite correspondingFightingSprite))
            {
                characterSprites[1] = correspondingFightingSprite;
            }

            else
            {
                //if the fighting sprite is not found, keep the neutral sprite
                characterSprites[1] = characterSprites[0];
            }
            
        }

        spriteRenderer.sprite = characterSprites[0];
    }

    

    // Create the mapping between neutral and fighting sprites
    private void CreateSpriteMap()
    {
        if (neutralSprites.Length == fightingSprites.Length)
        {
            for (int i = 0; i < neutralSprites.Length; i++)
            {
                spriteMap[neutralSprites[i]] = fightingSprites[i];
            }
             
        }
    }




}
