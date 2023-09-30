using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class adjusts the size of particles.
/// </summary>
public class ParticleSizeAdjuster : MonoBehaviour
{
    public ParticleSystem particleSystem1;


    /// <summary>
    /// Checks to make sure particle is not null
    /// </summary>
    void Start()
    {
        if (GetComponent<ParticleSystem>() == null)
        {
            Debug.LogError("Particle System not assigned!");
            return;
        }
        float scale = 0.1f;
        var psys = GetComponentsInChildren<ParticleSystem>();
        foreach (var ps in psys)
        {
            var main = ps.main;
            main.scalingMode = ParticleSystemScalingMode.Local;
            ps.transform.localScale = new Vector3(scale, scale, scale);     
        }

    }

    
}
