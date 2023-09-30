using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class for the suction tubes that suck up the ball and shoot them out faster.
/// </summary>
public class SuctionTube : MonoBehaviour
{
    private float speed = 1.5f;

    /// <summary>
    /// When the ball enters the suctionTube it increases speed.
    /// </summary>
    /// <param name="collider">The ball.</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //checks if the collider is the regular speed boost, or the maxSpeedBoost
        if (this.gameObject.name == "MaxSpeedBoost") {
            this.speed = 1.5f; 
        }else {
            this.speed = 1.2f;
        }

        Rigidbody2D ball = collider.GetComponent<Rigidbody2D>();
        if (ball != null)
        {
            Vector2 boostedSpeed = ball.velocity * speed;
            ball.velocity = boostedSpeed;
        }
    }

}
