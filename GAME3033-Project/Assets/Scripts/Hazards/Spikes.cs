using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    [SerializeField]
    private int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Lower player's health
            other.gameObject.GetComponent<PlayerController>().currentHealth -= damage;

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
