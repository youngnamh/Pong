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
    private float timeInterval = 1;
    private bool isGeneratorOn = false;



    public void startGenerator() {
        this.isGeneratorOn = true;
        StartCoroutine(SpawnCollectibles());
    }

    public void stopGenerator() {
        this.isGeneratorOn = false;
        DestroyALlCollectibles();

    }

    private IEnumerator SpawnCollectibles()
    {
        while (isGeneratorOn) // Infinite loop for continuous spawning
        {
            // Generate a random position within the spawn area
            Vector2 spawnPosition = new Vector2(
                Random.Range(-spawnArea.x, spawnArea.x),
                Random.Range(-spawnArea.y, spawnArea.y)
            );

            // Instantiate the Coin prefab at the random position
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(timeInterval); 
        }
        print("coroutine stopped");
    }

    private void DestroyALlCollectibles()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("collectible");

        // Iterate through the found GameObjects and destroy them
        foreach (GameObject coin in coins)
        {
            Destroy(coin);
        }
    }
}
