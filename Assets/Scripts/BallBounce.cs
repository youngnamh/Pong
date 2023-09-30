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
    private bool isFirstHit = true;
    private bool player1HitLast = false;
    private Rigidbody2D rb;
    public GameObject hitSFX;
    public GameObject drumSFX;
    public GameObject scoreSFX;
    public GameObject guitarSFX;
    public BallMovement ballMovement;
    public ScoreManager scoreManager;
    public PowerBarManager powerBarManager;
    public CollectibleGenerator collectibleGenerator;
    public BreakableGenerator breakableGenerator;
    public GameObject particleEffectPlanet;
    public GameObject particleEffectScore;
    public GameObject particleEffectBonusHit;

    
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }


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

        ballMovement.MoveBall(new Vector2(positionX, positionY), bonus);

    }

    /// <summary>
    /// This method handles collectibles. The ball does not collide with them,
    /// and based on who hit last, they get power bar points. The first movement
    /// before a hit cannot trigger a collectible.
    /// </summary>
    /// <param name="collider">The collectible being triggered</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //if the ball collides with a collectible
        if(collider.gameObject.CompareTag("collectible"))
        {   
            //if its player 1's collectible
            if(player1HitLast && !isFirstHit) {
                Destroy(collider.gameObject);
                int powerLevel = powerBarManager.getPlayer1PL();
                powerBarManager.setPlayer1PL(powerLevel + 7);
                this.collectibleGenerator.decreaseTimeInterval();
            //if its player 2's collectible    
            } else if (!player1HitLast && !isFirstHit) {
                Destroy(collider.gameObject);
                int powerLevel = powerBarManager.getPlayer2PL();
                powerBarManager.setPlayer2PL(powerLevel + 7);
                this.collectibleGenerator.decreaseTimeInterval();
            }
            Instantiate(hitSFX, transform.position, transform.rotation);
        }
    }
    
    
    /// <summary>
    /// This method will decide whether the ball should bounce after colliding with an object, or 
    /// start a new round if someone scored a point.
    /// </summary>
    /// <param name="collision">The collision object of a ball hitting either a border or a paddle</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the ball collides with Player 1
        if(collision.gameObject.name == "Player 1")
        {
            Instantiate(guitarSFX, transform.position, transform.rotation);      
            ballMovement.IncreaseHitCounter();
            // player1 was the last to hit the ball (for collectibles)
            this.player1HitLast = true;
            //collectibles are active
            this.isFirstHit = false;
            //add 1 point to power bar
            int powerLevel = powerBarManager.getPlayer1PL();
            int powerMax = powerBarManager.getPowerMax();
            if(powerLevel >= powerMax ) {
                powerBarManager.setPlayer1PL(0);
                Bounce(collision, true);
                Instantiate(guitarSFX, transform.position, transform.rotation);

            // launch power shot if power ball is full    
            } else {
                powerBarManager.setPlayer1PL(powerLevel + 3);
                Bounce(collision);
            }
        } 
        else if(collision.gameObject.name == "Player 2")
        {
            Instantiate(guitarSFX, transform.position, transform.rotation);      
            ballMovement.IncreaseHitCounter();
            this.player1HitLast = false;
            this.isFirstHit = false;
            int powerLevel = powerBarManager.getPlayer2PL();
            int powerMax = powerBarManager.getPowerMax();
            if(powerLevel >= powerMax ) {
                powerBarManager.setPlayer2PL(0);
                Instantiate(particleEffectScore,collision.transform.position, Quaternion.identity);
                Bounce(collision, true);
            } else {
                powerBarManager.setPlayer2PL(powerLevel + 3);
                Bounce(collision);
            }            

        }

        //Player 1 gets a point
        else if(collision.gameObject.name == "Right Border")
        {
            Instantiate(particleEffectBonusHit,rb.transform.position, Quaternion.identity);
            Instantiate(scoreSFX, transform.position, transform.rotation);
            //Start new round, collectibles deactivated
            scoreManager.Player1Goal();
            ballMovement.Player1Start = false;
            StartCoroutine(ballMovement.Launch());
            this.isFirstHit = true;
            collectibleGenerator.stopGenerator();
            breakableGenerator.stopGenerator();
        }

        else if(collision.gameObject.name == "Left Border")
        {
            Instantiate(particleEffectBonusHit,rb.transform.position, Quaternion.identity);
            Instantiate(scoreSFX, transform.position, transform.rotation);
            scoreManager.Player2Goal();
            ballMovement.Player1Start = true;
            StartCoroutine(ballMovement.Launch());            
            player1HitLast = false;
            this.isFirstHit = true;     
            collectibleGenerator.stopGenerator();  
            breakableGenerator.stopGenerator();
             
        }

        //Any breakable objects should be destroyed and they should spawn quicker
        else if(collision.gameObject.CompareTag("breakable"))
        {
            Instantiate(particleEffectPlanet,collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            this.breakableGenerator.decreaseTimeInterval();
            Instantiate(drumSFX, transform.position, transform.rotation);
        } else {
            Instantiate(drumSFX, transform.position, transform.rotation);
        }



        
    }

    public bool getPlayerHitLast() => this.player1HitLast;

}
