using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class represents the computer player. It is embarrassing how a few lines of code 
/// is much better than me at the game.
/// </summary>
public class Player2 : MonoBehaviour
{
    private float racketSpeed;
    private float resetSpeed;
    private int counter;
    private Rigidbody2D rb;
    public Rigidbody2D ball;
    public BallMovement ballMovement;


    /// <summary>
    /// This method sets the computer to the rb attribute and racketSpeed. The
    /// resetSpeed is how fast the computer goes back to the middle.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        this.racketSpeed = 8;
        this.resetSpeed = 2;
    }

    /// <summary>
    /// This method controls the playing strategy of the computer.
    /// </summary>
    private void FixedUpdate() {

        // if the ball is coming towards computer
        if (this.ball.velocity.x > 0.0f) {

            //movePosition to the current Ball position 
            Vector3 targetPosition = new Vector3(transform.position.x, this.ball.position.y, transform.position.z);
            Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, racketSpeed * Time.deltaTime);
            rb.MovePosition(newPosition);

        // if the ball is moving away     
        } else if (this.ball.velocity.x < 0.0f){
            
            //movePosition to the middle position 
            Vector3 targetPosition = new Vector3(transform.position.x, 0.0f, transform.position.z);
            Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, resetSpeed * Time.deltaTime);
            rb.MovePosition(newPosition);            
        }

        int hitCounter = ballMovement.HitCounter;

        //adjust the computers racket speed to account for it being better than me. 
        if (hitCounter < 5) {
            this.racketSpeed = 8;
        } else if (hitCounter >= 5 && hitCounter < 10) {
            this.racketSpeed = 7;
        } else if (hitCounter >= 10) {
            this.racketSpeed = 6;
        }

    }

}
