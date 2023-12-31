using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class creates collectibles randomly throughout the game. 
/// </summary>
public class CollectibleGenerator : MonoBehaviour
{
    public GameObject coinPrefab;
    private Vector2 spawnArea = new Vector2(7f,4f);
    private float initialTimeInterval = 5;
    private float currentTimeInterval = 5;
    private bool isGeneratorOn = false;
    private int collectibleCount = 0;


    /// <summary>
    /// This method starts the Generator.
    /// </summary>
    public void startGenerator() {
        this.isGeneratorOn = true;
        this.currentTimeInterval = this.initialTimeInterval;
        StartCoroutine(SpawnCollectibles());
    }

    /// <summary>
    /// This method stops the Generator.
    /// </summary>
    public void stopGenerator() {
        this.isGeneratorOn = false;
        DestroyALlCollectibles();

    }

    /// <summary>
    /// While the generator is on, this method spawns a collectible each time the initialTimeInterval passes.
    /// </summary>
    /// <returns>IENumerator to wait the time interval to be called again</returns>
    private IEnumerator SpawnCollectibles()
    {
        while (isGeneratorOn) // Infinite loop for continuous spawning
        {
            yield return new WaitForSeconds(currentTimeInterval); 
            // Generate a random position within the spawn area
            Vector2 spawnPosition = new Vector2(
                Random.Range(-spawnArea.x, spawnArea.x),
                Random.Range(-spawnArea.y, spawnArea.y)
            );

            // Instantiate the Coin prefab at the random position
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

        }
    }

    public void decreaseTimeInterval(){
        if(collectibleCount<10){
            collectibleCount++;
            this.currentTimeInterval -= 0.2f;
        }
    }

    /// <summary>
    /// This method destroys all the collectibles that are currently active. 
    /// </summary>
    private void DestroyALlCollectibles()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("collectible");

        // Iterate through the found GameObjects and destroy them
        foreach (GameObject coin in coins)
        {
            Destroy(coin);
        }
        collectibleCount = 0;
    }
}
