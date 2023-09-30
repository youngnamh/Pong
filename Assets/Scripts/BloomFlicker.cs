using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BloomFlicker : MonoBehaviour
{
public PostProcessVolume postProcessVolume;
    public float minIntensity = -1.5f;
    public float maxIntensity = 5.0f;
    public float flickerSpeed = 1.0f;

    private Bloom bloomLayer;
    private float t = 0.0f;

    private void Start()
    {
        if (postProcessVolume != null && postProcessVolume.profile.TryGetSettings(out bloomLayer))
        {
            // Adjust initial bloom intensity to your liking
            bloomLayer.intensity.value = minIntensity;
        }
    }

    private void Update()
    {
        if (bloomLayer != null)
        {
            // Calculate the flickering intensity using a sine wave
            float flickerIntensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.Sin(t * flickerSpeed));

            // Set the bloom intensity
            bloomLayer.intensity.value = flickerIntensity;

            // Increment the time variable
            t += Time.deltaTime;
        }
    }
}
