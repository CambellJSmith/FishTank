using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private float speed;
    private Vector3 targetPosition;
    private bool movingLeft = false;
    private bool rotating = false;
    private float rotationSpeed = 360f; // Degrees per second

    void Start()
{
    // Set random speed between 0.4 and 5
    speed = Random.Range(0.4f, 5f);

    // Set random bright color
    float hue = Random.Range(0f, 1f);
    float saturation = Random.Range(0.0f, 0.8f);
    float value = Random.Range(0.5f, 1f);
    GetComponent<SpriteRenderer>().color = Color.HSVToRGB(hue, saturation, value);

    // Set random scale between 1 and 1.5 for both x and y, always positive
    float scale = Mathf.Abs(Random.Range(1f, 1.5f));
    transform.localScale = new Vector3(scale, scale, 1f);

    // Set initial target position within the camera's boundary
    float cameraHeight = Camera.main.orthographicSize;
    float cameraWidth = cameraHeight * Camera.main.aspect;
    float minX = Camera.main.transform.position.x - cameraWidth;
    float maxX = Camera.main.transform.position.x + cameraWidth;
    float minY = Camera.main.transform.position.y - cameraHeight;
    float maxY = Camera.main.transform.position.y + cameraHeight;
    targetPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
}


    void Update()
    {
        if (rotating)
        {
            // Continue rotating towards target rotation
            float targetRotation = movingLeft ? 180f : 0f;
            Quaternion targetQuaternion = Quaternion.Euler(0f, targetRotation, 0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetQuaternion, rotationSpeed * Time.deltaTime);

            // Check if rotation is complete
            if (Quaternion.Angle(transform.rotation, targetQuaternion) < 0.1f)
            {
                rotating = false;
            }
        }
        else
        {
            // Move towards target position at the set speed
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Change direction when reaching target position
            if (transform.position == targetPosition)
            {
                // Set new random target position within the camera's boundary
                float cameraHeight = Camera.main.orthographicSize;
                float cameraWidth = cameraHeight * Camera.main.aspect;
                float minX = Camera.main.transform.position.x - cameraWidth;
                float maxX = Camera.main.transform.position.x + cameraWidth;
                float minY = Camera.main.transform.position.y - cameraHeight;
                float maxY = Camera.main.transform.position.y + cameraHeight;
                targetPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
                rotating = true;
            }
        }

        // Check if moving left or right
        if (transform.position.x < targetPosition.x)
        {
            // Moving right
            if (movingLeft)
            {
                rotating = true;
            }
            movingLeft = false;
        }
        else if (transform.position.x > targetPosition.x)
        {
            // Moving left
            if (!movingLeft)
            {
                rotating = true;
            }
            movingLeft = true;
        }
    }
}
