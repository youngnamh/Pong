using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used for the cases where a ball collides with borders or paddles. It is very closely
/// linked with the BallMovement class and calls the MoveBall function from BallMovement 
/// in order to designate the direction where the ball must bounce.
/// </summary>
public class BallBounce : MonoBehaviour
{
    public GameObject hitSFX;
    public BallMovement ballMovement;
    public ScoreManager scoreManager;
    public PowerBarManager powerBarManager;
    public bool player1HitLast = false;


    /// <summary>
    /// This method uses the collision object to calculate the direction the ball should bounce to. 
    /// </summary>
    /// <param name="collision">The collision object of a ball hitting eitehr a border or a paddle</param>
    /// <param name="bonus">A boolean for if this bounce has a bonus speed multiplier</param>
    private void Bounce(Collision2D collision, bool bonus = false)
    {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.y;

        //check if collision is Player1 or Player2
        float positionX;
        if(collision.gameObject.name == "Player 1")
        {
            positionX = 1;
        }
        else
        {
            positionX = -1;
        }

        float positionY = (ballPosition.y - racketPosition.y) / racketHeight;

        ballMovement.IncreaseHitCounter();
        ballMovement.MoveBall(new Vector2(positionX, positionY), bonus);

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //if the ball collides with a collectible
        if(collider.gameObject.CompareTag("collectible"))
        {
            console.log("player1Hitlast: "+player1HitLast)
            Destroy(collider.gameObject);
            if(player1HitLast) {
                console.log("player1 got collectible");
                int powerLevel = powerBarManager.getPlayer1PL();
                powerBarManager.setPlayer1PL(powerLevel + 1);
            } else {
                console.log("player2 got collectible");
                int powerLevel = powerBarManager.getPlayer2PL();
                powerBarManager.setPlayer2PL(powerLevel + 1);
            }
        }
    }
    
    
    /// <summary>
    /// This method will decide whether the ball should bounce after colliding with an object, or 
    /// start a new round if someone scored a point.
    /// </summary>
    /// <param name="collision">The collision object of a ball hitting either a border or a paddle</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.name == "Player 1")
        {
            player1HitLast = true;
            int powerLevel = powerBarManager.getPlayer1PL();
            int powerMax = powerBarManager.getPowerMax();
            if(powerLevel >= powerMax ) {
                powerBarManager.setPlayer1PL(0);
                Bounce(collision, true);
            } else {
                powerBarManager.setPlayer1PL(powerLevel + 1);
                Bounce(collision);
            }
        } 
        else if(collision.gameObject.name == "Player 2")
        {
            player1HitLast = false;
            int powerLevel = powerBarManager.getPlayer2PL();
            int powerMax = powerBarManager.getPowerMax();
            if(powerLevel >= powerMax ) {
                powerBarManager.setPlayer2PL(0);
                Bounce(collision, true);
            } else {
                powerBarManager.setPlayer2PL(powerLevel + 1);
                Bounce(collision);
            }            

        }

        else if(collision.gameObject.name == "Right Border")
        {
            scoreManager.Player1Goal();
            ballMovement.player1Start = false;
            StartCoroutine(ballMovement.Launch());
            player1HitLast = true;
        }

        else if(collision.gameObject.name == "Left Border")
        {
            scoreManager.Player2Goal();
            ballMovement.player1Start = true;
            StartCoroutine(ballMovement.Launch());
            player1HitLast = true;
        }

        Instantiate(hitSFX, transform.position, transform.rotation);
    }

    public bool getPlayerHitLast() => this.player1HitLast;

}
