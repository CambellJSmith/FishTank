using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToCameraBounds : MonoBehaviour
{
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        ScaleSprite();
    }

    private void ScaleSprite()
    {
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        float spriteWidth = spriteRenderer.sprite.bounds.size.x;
        float spriteHeight = spriteRenderer.sprite.bounds.size.y;

        float xScale = cameraWidth / spriteWidth;
        float yScale = xScale;

        transform.localScale = new Vector3(xScale, yScale, 1.01f);
    }
}
