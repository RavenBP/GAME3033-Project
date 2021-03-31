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
    GameObject pickupPrefab;

    [SerializeField]
    private Transform[] pickupPositions;

    private bool invokeRunning = false;

    void CheckPickups()
    {
        // One of the pickups have been picked up
        if (Pickup.pickupsExisting >= pickupPositions.Length)
        {
            Debug.Log(Pickup.pickupsExisting.ToString() + " pickups remaining.");
        }
        else
        {
            Debug.Log("A pickup was picked up");
            Debug.Log(Pickup.pickupsExisting.ToString() + " pickups remaining.");
            Debug.Log(pickupPositions.Length + " = pickupPositions.Length");
            invokeRunning = false;
            GameManager.Instance.currentAreaCompleted = true;
            GameManager.Instance.loopCount += 1;

            Debug.Log("Loop increased to: " + GameManager.Instance.loopCount);

            exit.SetActive(false);

            // Destroy any other pickups
            Pickup[] spawnedPickups = FindObjectsOfType<Pickup>();

            for (int i = 0; i < spawnedPickups.Length; i++)
            {
                Destroy(spawnedPickups[i].gameObject);
                Pickup.pickupsExisting--;
            }

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

    void SpawnPickups()
    {
        for (int i = 0; i < pickupPositions.Length; i++)
        {
            Instantiate(pickupPrefab, pickupPositions[i]);
            Pickup.pickupsExisting++;
        }

        invokeRunning = true;
        InvokeRepeating(nameof(CheckPickups), 0.0f, 1.0f);

        entrance.SetActive(true);
        exit.SetActive(true);
    }
}
