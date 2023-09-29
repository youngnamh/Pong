using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float racketSpeed;
    private float resetSpeed;
    private Rigidbody2D rb;
    public Rigidbody2D ball;
    private int counter;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        this.racketSpeed = 10;
        this.resetSpeed = 3;
    }

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
    }

}
