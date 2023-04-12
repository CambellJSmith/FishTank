using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // The prefab to spawn
    public float minSpawnTime = 0.3f; // The minimum time between spawns
    public float maxSpawnTime = 2f; // The maximum time between spawns
    public int maxSpawnCount = 30; // The maximum number of spawned objects allowed

    private Camera mainCamera; // The main camera in the scene
    private float timeUntilNextSpawn; // The time until the next spawn
    private int spawnCount = 0; // The number of spawned objects

    void Start()
    {
        // Get the main camera in the scene
        mainCamera = Camera.main;

        // Set the time until the next spawn
        timeUntilNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Update()
    {
        // Decrease the time until the next spawn
        timeUntilNextSpawn -= Time.deltaTime;

        // If the time until the next spawn is less than or equal to zero
        if (timeUntilNextSpawn <= 0)
        {
            // Reset the time until the next spawn
            timeUntilNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);

            // Check if the number of spawned objects is less than the maximum allowed and less than 15
            if (GameObject.FindGameObjectsWithTag("Fish").Length < maxSpawnCount && spawnCount < 15)
            {
                // Calculate the position to spawn the prefab
                Vector3 spawnPosition = new Vector3(Random.Range(mainCamera.transform.position.x - mainCamera.orthographicSize, mainCamera.transform.position.x + mainCamera.orthographicSize), mainCamera.transform.position.y + mainCamera.orthographicSize, 0);

                // Spawn the prefab at the calculated position
                Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

                // Increment the number of spawned objects
                spawnCount++;
            }
        }
    }
}
