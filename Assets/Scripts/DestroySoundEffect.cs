using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class destroys a sound effect after a set amount of time. 
/// </summary>
public class DestroySoundEffect : MonoBehaviour
{
    /// <summary>
    /// Destroys the gameObject.
    /// </summary>
    void Start()
    {
        Destroy(gameObject, 1);        
    }

}
