using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    [SerializeField]
    private int damage = 10;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Lower player's health
            other.gameObject.GetComponent<PlayerController>().currentHealth -= damage;
            audioSource.Play();

            // Player has no health
            if (other.gameObject.GetComponent<PlayerController>().currentHealth <= 0)
            {
                SceneManager.LoadScene("ResultsScene");
            }
        }
        else if (other.CompareTag("Enemy"))
        {
            // Lower enemy's health
            other.gameObject.GetComponentInChildren<Enemy>().currentHealth -= damage;
            audioSource.Play();

            // Enemy has no health
            if (other.gameObject.GetComponentInChildren<Enemy>().currentHealth <= 0)
            {
                // Destroy enemy
                Enemy.enemiesExisting--;
                Destroy(other.gameObject.transform.parent.gameObject);
            }
        }
    }
}
