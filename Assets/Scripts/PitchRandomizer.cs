using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class adds some randomness to the pitch of sounds so they arent as repetetive. 
/// </summary>
public class PitchRandomizer : MonoBehaviour
{
    private float minPitch = 0.8f;  // Minimum pitch value
    private float maxPitch = 1.2f;  // Maximum pitch value

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        // Generate a random pitch value within the specified range
        float randomPitch = Random.Range(minPitch, maxPitch);

        // Set the pitch of the AudioSource to the random value
        audioSource.pitch = randomPitch;
    }
}
