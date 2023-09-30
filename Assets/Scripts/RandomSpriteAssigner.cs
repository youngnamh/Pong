using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Class that assigns a random sprite to an object out of a collection of sprites.
/// </summary>
public class NewBehaviourScript : MonoBehaviour
{
    public Sprite[] imageOptions; 
    public SpriteRenderer spriteRenderer;

    /// <summary>
    /// This method randomly selects the sprite.
    /// </summary>
    void Start()
    {
        if (imageOptions.Length == 0)
        {
            Debug.LogError("No images assigned to imageOptions array.");
            return;
        }

        // Generate a random index within the range of the array
        int randomIndex = Random.Range(0, imageOptions.Length);

        // Assign the selected sprite to the prefab's SpriteRenderer
        spriteRenderer.sprite = imageOptions[randomIndex];
        
    }

}
