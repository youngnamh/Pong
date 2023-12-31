using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class that controls the ball, and how fast it moves. 
/// </summary>
public class BallMovement : MonoBehaviour
{

    private float startSpeed = 5;
    private float extraSpeed = 0.5f;
    private float maxExtraSpeed = 10;
    private bool player1Start = true;
    private int hitCounter = 0;
    private Rigidbody2D rb;
    public PowerBarManager powerBarManager;
    public CollectibleGenerator collectibleGenerator;
    public BreakableGenerator breakableGenerator;

    /// <summary>
    /// Set Rigidbody value and start the coroutine Launch().
    /// </summary>
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(Launch());
    }

    private void FixedUpdate()
    {
        //if the-ball-is-out-of-bounds, restart -the-ball
        if (transform.position.x > 10 || transform.position.x <-10 ||
        transform.position.y>5 || transform.position.y<-5)
        {
            RestartBall();
            StartCoroutine(Launch());
        } 

    }

    /// <summary>
    /// Sets the ball back in the middle of the screen.
    /// </summary>
    private void RestartBall()
    {
        rb.velocity = new Vector2(0,0);
        transform.position = new Vector2(0,0);
    }


    /// <summary>
    /// After a delay of one second, calls MoveBall() at a specified starting Vector.
    /// </summary>
    /// <returns>Coroutine for ball movement.</returns>
    public IEnumerator Launch()
    {
        RestartBall();
        hitCounter = 0;
        yield return new WaitForSeconds(1.5f);

        if(player1Start)
        {
            MoveBall(new Vector2(-1,0));
            this.collectibleGenerator.startGenerator();
            this.breakableGenerator.startGenerator();
        }
        else
        {
            MoveBall(new Vector2(1,0));
            this.collectibleGenerator.startGenerator();
            this.breakableGenerator.startGenerator();
        }
    }

    public void StopBall(){
        MoveBall(new Vector2(0,0));
    }

    /// <summary>
    /// Normalizes the direction of the ball and sets a new ballSpeed based on the hitCounter.
    /// </summary>
    /// <param name="direction">A Vector2 object specifying the direction of the ball.</param>
    /// <param name="bonus">A boolean denoting whether or not it is a bonus hit.</param>
    public void MoveBall(Vector2 direction, bool bonus = false)
    {

        direction = direction.normalized;

        //bonus speed is added if its 3rd hit for now.
        float bonusSpeed = 0;
        if (bonus) {
            bonusSpeed = CalculateBonus();
        }
        float ballSpeed = (startSpeed + hitCounter * extraSpeed) + bonusSpeed;

        rb.velocity = direction * ballSpeed;

    }

    /// <summary>
    /// This method calculates how much the bonus power should be depending on how long the round is.
    /// </summary>
    /// <returns>The bonus amount.</returns>
    public int CalculateBonus() {
        if(this.hitCounter < 10) {
            return 20;
        } else {
            return 10;
        }
    }

    /// <summary>
    /// Increments the hit counter by 1.
    /// </summary>
    public void IncreaseHitCounter()
    {
        if(hitCounter * extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
        }
    }

    public bool Player1Start
    {
        get { return player1Start; }
        set { player1Start = value; }
    }

    // Getter for hitCounter
    public int HitCounter
    {
        get { return hitCounter; }
        set { hitCounter = value; }
    }
}




