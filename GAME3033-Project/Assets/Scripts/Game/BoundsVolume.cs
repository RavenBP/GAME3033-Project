using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoundsVolume : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.name);

            // Relocate player
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.gameObject.transform.position = spawnPosition.position;
            other.gameObject.GetComponent<CharacterController>().enabled = true;

            // Lower player health
            other.gameObject.GetComponent<PlayerController>().currentHealth -= 10;

            // Player has no health remaining
            if (other.gameObject.GetComponent<PlayerController>().currentHealth <= 0)
            {
                SceneManager.LoadScene("ResultsScene");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider>().size);
    }
}
