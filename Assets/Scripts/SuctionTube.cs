using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuctionTube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Rigidbody2D ball = collider.GetComponent<Rigidbody2D>();
        if (ball != null)
        {
            Vector2 boostedSpeed = ball.velocity * new Vector2(2.0f,0f);
            ball.velocity = boostedSpeed;
        }
    }
}
