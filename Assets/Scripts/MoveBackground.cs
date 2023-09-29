using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class moves the background to create an alive effect.
/// </summary>
public class MoveBackground : MonoBehaviour
{
    public Transform backgroundHolder;
    private float speed = 0.1f;
    private bool isMovingDown = true;

    /// <summary>
    /// Starts the movements.
    /// </summary>
    private void Start()
    {
        StartCoroutine(MoveBackgroundRoutine());
    }

    /// <summary>
    /// This method will change the direction of the movement if the end of the background is reached.
    /// </summary>
    private void Update()
    {
        if(backgroundHolder.position.y <= -2.5){
            this.isMovingDown=false;
        } else if (backgroundHolder.position.y >= 2) {
            this.isMovingDown=true;
        }
    }

    /// <summary>
    /// This method has the infinite loop that actually Translates the Image.
    /// </summary>
    /// <returns></returns>
    private IEnumerator MoveBackgroundRoutine()
    {
        while (true) // Infinite loop
        {
            if (!isMovingDown)
            {
                backgroundHolder.Translate(Vector2.up * speed * Time.deltaTime);
            }
            else
            {
                backgroundHolder.Translate(Vector2.down * speed * Time.deltaTime);
            }

            yield return null; // Yielding null to continue in the next frame
        }
    }
}







