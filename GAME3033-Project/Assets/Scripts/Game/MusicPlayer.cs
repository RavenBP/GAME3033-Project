using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    AudioSource audioSource1;
    [SerializeField]
    AudioSource audioSource2;

    public float volume = 0.0f;

    public bool transitioning = false;
    public bool playingPlatformerTrack = false;

    private void Update()
    {
        if (transitioning == true)
        {
            if (playingPlatformerTrack == false)
            {
                // Manage audio source volumes
                audioSource1.volume = 1.0f - volume;
                audioSource2.volume = volume;

                volume += 0.15f * Time.deltaTime;

                if (volume >= 0.5f)
                {
                    transitioning = false;
                    audioSource1.volume = 0.0f;
                    audioSource2.volume = 0.5f;
                    audioSource1.Stop();
                }
            }
            else if (playingPlatformerTrack == true)
            {
                // Manage audio source volumes
                audioSource2.volume = 0.5f - volume;
                audioSource1.volume = volume;

                volume += 0.3f * Time.deltaTime;

                if (volume >= 1)
                {
                    transitioning = false;
                    audioSource2.volume = 0;
                    audioSource1.volume = 1;
                    audioSource2.Stop();
                }
            }
        }
    }

    public void BeginPlayingPlatformerTrack()
    {
        audioSource1.Play();
    }

    public void BeginPlayingShooterTrack()
    {
        audioSource2.Play();
    }
}
