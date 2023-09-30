using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class creates breakables randomly throughout the game. 
/// </summary>
public class BreakableGenerator : MonoBehaviour
{
    public GameObject blockPrefab;
    private Vector2 spawnArea = new Vector2(5f,4f);
    private float initialTimeInterval = 8;
    private float currentTimeInterval;
    private bool isGeneratorOn = false;
    private int breakableCount = 0;


    /// <summary>
    /// This method starts the Generator.
    /// </summary>
    public void startGenerator() {
        this.isGeneratorOn = true;
        this.currentTimeInterval = this.initialTimeInterval;
        StartCoroutine(SpawnBreakables());
    }

    /// <summary>
    /// This method stops the Generator.
    /// </summary>
    public void stopGenerator() {
        this.isGeneratorOn = false;
        DestroyAllCollectibles();

    }

    /// <summary>
    /// While the generator is on, this method spawns a collectible each time the InitialTimeInterval passes.
    /// </summary>
    /// <returns>IENumerator to wait the time interval to be called again</returns>
    private IEnumerator SpawnBreakables()
    {
        while (isGeneratorOn) // Infinite loop for continuous spawning
        {

            // Generate a random position within the spawn area
            Vector2 spawnPosition = new Vector2(
                Random.Range(-spawnArea.x, spawnArea.x),
                Random.Range(-spawnArea.y, spawnArea.y)
            );

            // Instantiate the Coin prefab at the random position
            Instantiate(blockPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(this.currentTimeInterval); 
        }
    }

    public void decreaseTimeInterval(){
        if(breakableCount<10){
            breakableCount ++;
            this.currentTimeInterval -= 0.2f;
        }
    }

    /// <summary>
    /// This method destroys all the collectibles that are currently active. 
    /// </summary>
    private void DestroyAllCollectibles()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("breakable");

        // Iterate through the found GameObjects and destroy them
        foreach (GameObject block in blocks)
        {
            Destroy(block);
        }
        breakableCount = 0;
    }
}
