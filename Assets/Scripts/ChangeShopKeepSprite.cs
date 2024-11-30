using UnityEngine;
using UnityEngine.UI;

public class ChangeShopKeepSprite : MonoBehaviour
{
    public Image uiImage; // Reference to the UI Image component
    public Sprite[] sprites; // Array of sprites to animate
    public float frameDuration = 0.2f; // Time per frame in seconds

    private int currentFrame = 0; // Index of the current sprite
    private float timer = 0f; // Timer to track frame duration

    void Update()
    {
        if (sprites == null || sprites.Length == 0 || uiImage == null)
            return;

        // Increment the timer by the time since the last frame
        timer += Time.deltaTime;

        // Check if it's time to switch to the next sprite
        if (timer >= frameDuration)
        {
            // Move to the next frame, looping back to the start if needed
            currentFrame = (currentFrame + 1) % sprites.Length;

            // Update the sprite
            uiImage.sprite = sprites[currentFrame];

            // Reset the timer
            timer = 0f;
        }
    }
}
