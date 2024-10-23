using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    // Time to switch between fighting and neutral sprite
    public float spriteCycleTime;
    public bool isNeutralSprite;
    public SelectedCharacter character;

    // Movement parameters
    public float moveRangeX = 1f; // Horizontal movement range
    public float moveRangeY = 1f; // Vertical movement range
    public float moveSpeed = 1f; // Speed of movement

    private Vector3 targetPosition; // The position the character is moving toward
    private Vector3 initialPosition; // The character's initial position at the start of the scene

    // Start is called before the first frame update
    void Start()
    {
        spriteCycleTime = 10f;
        isNeutralSprite = true;

        // Store the initial position of the character
        initialPosition = transform.position;

        // Initialize the target position relative to the initial position
        SetRandomTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        // Handle sprite switching logic
        if (spriteCycleTime > 0)
        {
            spriteCycleTime -= Time.deltaTime;
        }
        else
        {
            // Switch sprites and reset the cycle
            if (isNeutralSprite)
            {
                character.SetExpressionFighting(true);
                isNeutralSprite = false;
            }
            else
            {
                character.SetExpressionFighting(false);
                isNeutralSprite = true;
            }
            ResetCycleTime(10f);
        }

        // Handle random movement
        MoveCharacter();
    }

    // Set the character's random target position within the defined range relative to the initial position
    private void SetRandomTargetPosition()
    {
        float randomX = UnityEngine.Random.Range(-moveRangeX, moveRangeX); // Use UnityEngine.Random
        float randomY = UnityEngine.Random.Range(-moveRangeY, moveRangeY); // Use UnityEngine.Random

        // Calculate the new target position relative to the initial position
        targetPosition = new Vector3(initialPosition.x + randomX, initialPosition.y + randomY, initialPosition.z);
    }

    // Function to move the character towards the target position
    private void MoveCharacter()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // If the character reaches the target, set a new random target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }
    }

    // Reset the timer for sprite switching
    public void ResetCycleTime(float newTime)
    {
        spriteCycleTime = newTime;
    }
}
