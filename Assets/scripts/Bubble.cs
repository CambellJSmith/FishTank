using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private bool isClicked = false; // flag to track if the object has been clicked

    void Update()
    {
        // check for left click
        if (Input.GetMouseButtonDown(0))
        {
            // check if the mouse is over this object
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePos);

            if (hitCollider != null && hitCollider.gameObject == gameObject)
            {
                // object was clicked, start scaling up and fading out
                isClicked = true;
                StartCoroutine(ScaleUpAndFadeOut());
            }
        }
    }

    IEnumerator ScaleUpAndFadeOut()
    {
        float scaleTime = 1f; // time to scale up to full size and fade out
        float t = 0f; // current time

        // Get the SpriteRenderer component of the game object
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        while (t < scaleTime)
        {
            // Scale up over time
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 3f, t / scaleTime);

            // Reduce alpha value over time
            Color color = spriteRenderer.color;
            color.a = Mathf.Lerp(1f, 0f, t / scaleTime);
            spriteRenderer.color = color;

            t += Time.deltaTime;
            yield return null;
        }

        // Destroy the object after scaling up and fading out
        Destroy(gameObject);
    }
}
