using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTransition : MonoBehaviour
{
    [SerializeField]
    private MusicTrack musicTrack;

    private MusicPlayer musicPlayer;

    private void Start()
    {
        musicPlayer = GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<MusicPlayer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (musicTrack)
            {
                case MusicTrack.ShooterTrack:
                    // Track is already playing
                    if (musicPlayer.playingPlatformerTrack != false)
                    {
                        musicPlayer.playingPlatformerTrack = false;
                        musicPlayer.volume = 0.0f;
                        musicPlayer.transitioning = true;
                        musicPlayer.BeginPlayingShooterTrack();
                    }
                    break;
                case MusicTrack.PlatformerTrack:
                    // Track is already playing
                    if (musicPlayer.playingPlatformerTrack != true)
                    {
                        musicPlayer.playingPlatformerTrack = true;
                        musicPlayer.volume = 0.0f;
                        musicPlayer.transitioning = true;
                        musicPlayer.BeginPlayingPlatformerTrack();
                    }
                    break;
            }
        }
    }
}

public enum MusicTrack
{
    ShooterTrack,
    PlatformerTrack
}
