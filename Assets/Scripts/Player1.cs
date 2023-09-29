using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class represents your player. It controls how fast you can move and how you move.
/// </summary>
public class Player1 : MonoBehaviour
{
    [Range(1,20)]
    public float racketSpeed;
    private Rigidbody2D rb;
    private Vector2 racketDirection;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        racketDirection = new Vector2(0,directionY).normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = racketDirection * racketSpeed;
    }
}
