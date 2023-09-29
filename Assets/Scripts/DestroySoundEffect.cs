using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class destroys a sound effect after a set amount of time. 
/// </summary>
public class DestroySoundEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1);        
    }

}
