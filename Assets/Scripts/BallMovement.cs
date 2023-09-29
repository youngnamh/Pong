using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public float startSpeed;
    public float extraSpeed;
    public float maxExtraSpeed;
    public bool player1Start = true;
    private int hitCounter = 0;
    public Rigidbody2D rb;

    /// <summary>
    /// Set Rigidbody value and start the coroutine Launch().
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(Launch());
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
    /// <returns>Coroutine for ball movement</returns>
    public IEnumerator Launch()
    {
        RestartBall();
        hitCounter = 0;
        yield return new WaitForSeconds(1);

        if(player1Start)
        {
            MoveBall(new Vector2(-1,0));
        }
        else
        {
            MoveBall(new Vector2(1,0));
        }
    }

    /// <summary>
    /// Normalizes the direction of the ball and sets a new ballSpeed based on the hitCounter.
    /// </summary>
    /// <param name="direction">A Vector2 object specifying the direction of the ball</param>
    public void MoveBall(Vector2 direction)
    {

        direction = direction.normalized;

        //bonus speed is added if its 3rd hit for now.
        float bonusSpeed = 0;
        if(hitCounter % 3 == 0 && hitCounter != 0)
        {
            bonusSpeed = 10;
        }

        float ballSpeed = (startSpeed + hitCounter * extraSpeed) + bonusSpeed;

        rb.velocity = direction * ballSpeed;

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
}
