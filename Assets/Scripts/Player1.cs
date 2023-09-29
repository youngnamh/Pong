using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class represents your player. It controls how fast you can move and how you move.
/// </summary>
public class Player1 : MonoBehaviour
{
    private float racketSpeed = 10;
    private Rigidbody2D rb;
    private Vector2 racketDirection;


    /// <summary>
    /// This method sets the player as rb. 
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// This method sets the input controls and racketDirection.
    /// </summary>
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        racketDirection = new Vector2(0,directionY).normalized;
    }

    /// <summary>
    /// This method moves the racket.
    /// </summary>
    private void FixedUpdate()
    {
        rb.velocity = racketDirection * racketSpeed;
    }
}
