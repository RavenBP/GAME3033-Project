using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] audioClips;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayHealthSound()
    {
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }

    public void PlayDamageSound()
    {
        audioSource.clip = audioClips[1];
        audioSource.Play();
    }

    public void PlayJumpSound()
    {
        audioSource.clip = audioClips[2];
        audioSource.Play();
    }

    public void PlaySpeedSound()
    {
        audioSource.clip = audioClips[3];
        audioSource.Play();
    }
}
