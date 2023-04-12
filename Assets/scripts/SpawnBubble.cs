using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBubble : MonoBehaviour
{
    public GameObject bubbleToSpawn;    // The bubble object to be spawned
    public float spawnDistance = 1f;    // The distance under the camera's bounds to spawn the bubble
    public float spawnInterval = 1f;    // The interval at which to spawn the bubble
    public float despawnTime = 10f;     // The time after which bubbles despawn

    private Camera mainCamera;          // Reference to the main camera

    private void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(SpawnBubbles());
    }

    private IEnumerator SpawnBubbles()
    {
        while (true)
        {
            // Get the position of the camera's bottom edge in world space
            Vector3 cameraBottomEdge = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0f, mainCamera.nearClipPlane));

            // Spawn the bubble randomly on the x-axis, just below the camera's bounds
            float randomX = Random.Range(mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane)).x, mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, mainCamera.nearClipPlane)).x);
            Vector3 spawnPosition = new Vector3(randomX, cameraBottomEdge.y - spawnDistance, 0f);
            GameObject newBubble = Instantiate(bubbleToSpawn, spawnPosition, Quaternion.identity);

            // Destroy the bubble after despawnTime seconds
            Destroy(newBubble, despawnTime);

            // Wait for the spawn interval before spawning the next bubble
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
