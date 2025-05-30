using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDo : MonoBehaviour
{
    public GameObject Scout; // The enemy prefab to spawn

    public float spawnRate = 1f; // Time interval between spawns
    public float minSpawnRate = 0.2f; // Minimum spawn rate to prevent too fast spawning
    public float spawnMinX = -6.5f; // Minimum X position for spawning
    public float spawnMaxX = 6.5f;  // Maximum X position for spawning
    public float spawnMaxY = 5f; // Maximum Y position for spawning (not used, but can be useful)

    Vector2 camMin;
    Vector2 camMax;
    Camera mainCam;

    void Start()
    {
        // Cache camera reference and boundaries
        mainCam = Camera.main;
        camMin = mainCam.ViewportToWorldPoint(new Vector2(0, 0));
        camMax = mainCam.ViewportToWorldPoint(new Vector2(1, 1)); 

        // Start spawning enemies
        ScheduleNextEnemySpawn();

        // Start decreasing spawn rate every 30 seconds
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    void enemySpawn()
    {
        // Choose a random position along the top of the screen
        Vector2 spawnPos = new Vector2(Random.Range(spawnMinX, spawnMaxX), camMax.y);

        // Spawn the enemy with the original rotation
        Instantiate(Scout, spawnPos, Scout.transform.rotation);

        // Schedule the next enemy spawn
        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
        // Calculate a random delay based on current spawn rate
        float delay = Mathf.Clamp(Random.Range(minSpawnRate, spawnRate), 0.1f, 30f);
        Debug.Log("Next spawn in: " + delay + " seconds. SpawnRate: " + spawnRate);


        // Schedule the enemySpawn method to be called after the delay
        Invoke("enemySpawn", delay);
    }

    void IncreaseSpawnRate()
    {
        // Decrease the spawn rate until it reaches the minimum value
        if (spawnRate > 1f)
        {
            spawnRate=spawnRate-0.5f;
            Debug.Log("Spawn rate decreased to: " + spawnRate);
        }
        else
        {
            // Stop trying to decrease if we've reached the minimum
            CancelInvoke("IncreaseSpawnRate");
        }
    }
}
