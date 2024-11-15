using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkOutSceneManager : MonoBehaviour
{
    public SpriteRenderer character;

    // Start is called before the first frame update
    void Start()
    {
        // Set the character sprite from SelectedCharacterData
        if (SelectedCharacterData.SelectedGameCharacter != null)
        {
            character.sprite = SelectedCharacterData.SelectedGameCharacter;
        }
        else
        {
            Debug.LogWarning("SelectedGameCharacter is null.");
    }

}

   
}
