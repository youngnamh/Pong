using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public GameObject hitSFX;
    public BallMovement ballMovement;
    public ScoreManager scoreManager;
    public PowerBarManager powerBarManager;
    public bool player1HitLast = true;


    private void Bounce(Collision2D collision)
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
        ballMovement.MoveBall(new Vector2(positionX, positionY));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player 1")
        {
            player1HitLast = true;
            int powerLevel = powerBarManager.getPlayer1PL();
            powerBarManager.setPlayer1PL(powerLevel + 1);
            Bounce(collision);
        } 
        else if(collision.gameObject.name == "Player 2")
        {
            player1HitLast = false;
            int powerLevel = powerBarManager.getPlayer2PL();
            powerBarManager.setPlayer2PL(powerLevel + 1);
            Bounce(collision);
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

}
