using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupArea : MonoBehaviour
{
    [SerializeField]
    GameObject entrance;
    [SerializeField]
    GameObject exit;

    [SerializeField]
    GameObject pickupDoor;

    [SerializeField]
    GameObject pickupPrefab;

    [SerializeField]
    private Transform[] pickupPositions;

    private bool invokeRunning = false;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void CheckPickups()
    {
        // One of the pickups have been picked up
        if (Pickup.pickupsExisting < pickupPositions.Length)
        {
            invokeRunning = false;
            GameManager.Instance.currentAreaCompleted = true;
            GameManager.Instance.loopCount += 1;

            // Disable (open) the next door
            exit.SetActive(false);

            // Destroy any other pickups
            Pickup[] spawnedPickups = FindObjectsOfType<Pickup>();

            // Destroy all pickups
            for (int i = 0; i < spawnedPickups.Length; i++)
            {
                Destroy(spawnedPickups[i].gameObject);
            }

            // Reset number of total pickups
            Pickup.pickupsExisting = 0;

            CancelInvoke(nameof(CheckPickups));
            EnemyStats.IncreaseStats();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered pickup area");

            // Check to see if invoke is running
            if (invokeRunning == false)
            {
                // Check to see if the current (previous) area has been completed
                if (GameManager.Instance.currentAreaCompleted == true)
                {
                    SpawnPickups();
                    audioSource.Play();
                    pickupDoor.SetActive(false);
                }
                else
                {
                    Debug.Log("Current area has not yet been completed, go back!");
                }
            }
            else
            {
                Debug.Log("The invoke is already running!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("PLAYER EXITED PICKUP AREA");
            pickupDoor.SetActive(true);
        }
    }

    void SpawnPickups()
    {
        for (int i = 0; i < pickupPositions.Length; i++)
        {
            Instantiate(pickupPrefab, pickupPositions[i]);
            Pickup.pickupsExisting++;
        }

        invokeRunning = true;
        InvokeRepeating(nameof(CheckPickups), 0.0f, 1.0f);

        // Enable (close) room's doors
        entrance.SetActive(true);
        exit.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + GetComponent<BoxCollider>().center, GetComponent<BoxCollider>().size);
    }
}
