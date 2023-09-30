using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class that increase the pitch of a sound depending on how far in the game you are.
/// </summary>
public class PitchIncreaser : MonoBehaviour
{
    private BallMovement ballMovement;
    private float minPitch = 0.8f;  // Minimum pitch value
    private float maxPitch = 1.2f;  // Maximum pitch value

    private AudioSource audioSource;


    /// <summary>
    /// This method sets the ballMovement.
    /// </summary>
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        GameObject ballObject= GameObject.Find("Ball");

        if(ballObject != null)
        {
            ballMovement = ballObject.GetComponent<BallMovement>();
        }
    }

    /// <summary>
    /// This method calculates how much to increase pitch by.
    /// </summary>
    private void Start()
    {
        float increaseAmount;
        float increasedPitch;
        float hitCounter;
        if(ballMovement != null) {
            hitCounter = ballMovement.HitCounter;
        }else{
            hitCounter = Random.Range(minPitch, maxPitch);
        }   
        increaseAmount = 0.02f * hitCounter;
        if(minPitch + increaseAmount <= maxPitch){
            increasedPitch = minPitch + increaseAmount;
        } else {
            increasedPitch = maxPitch;
        }
        print(increasedPitch);
        // Set the pitch of the AudioSource to the random value
        audioSource.pitch = increasedPitch;

    }
}
