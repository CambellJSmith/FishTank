using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour {
    public GameObject prefabToSpawn; // The prefab to spawn when the egg hits the ground

    void Update() {
        // Check if the egg has hit the ground
        if (transform.position.y <= 0) {
            // Spawn the prefab
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
            
            // Destroy the egg
            Destroy(gameObject);
        }
    }
}