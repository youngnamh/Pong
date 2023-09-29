using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used for the background music of the Pong game. 
/// </summary>
public class BackgroundMusic : MonoBehaviour
{

    private static BackgroundMusic backgroundMusic;

    /// <summary>
    /// Checks if there is any pre existing background music. If there is not, it sets the music.
    /// </summary>
    void Awake()
    {
        if(backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
