using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbler : MonoBehaviour
{
    public AudioSource audioSource; // The AudioSource to play
    public float minTime = 1.0f; // Minimum time between audio plays
    public float maxTime = 2.0f; // Maximum time between audio plays
    public float minPitch = 0.4f; // Minimum pitch of the audio clip
    public float maxPitch = 1.6f; // Maximum pitch of the audio clip

    void Start()
    {
        StartCoroutine(PlayRandomAudio());
    }

    IEnumerator PlayRandomAudio()
    {
        while (true)
        {
            // Wait for a random amount of time before playing the audio clip
            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);

            // Set the pitch of the audio clip to a random value
            audioSource.pitch = Random.Range(minPitch, maxPitch);

            // Play the audio clip
            audioSource.Play();

            // Wait for a random amount of time before changing the pitch
            float pitchWaitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(pitchWaitTime);

            // Set the pitch of the audio clip back to its original value
            audioSource.pitch = 1.0f;
        }
    }
}
