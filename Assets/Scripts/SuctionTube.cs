using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class for the suction tubes that suck up the ball and shoot them out faster.
/// </summary>
public class SuctionTube : MonoBehaviour
{
    public float speed;

    /// <summary>
    /// When the ball enters the suctionTube it increases speed.
    /// </summary>
    /// <param name="collider">The ball.</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Rigidbody2D ball = collider.GetComponent<Rigidbody2D>();
        if (ball != null)
        {
            Vector2 boostedSpeed = ball.velocity * speed;
            ball.velocity = boostedSpeed;
        }
    }

}
