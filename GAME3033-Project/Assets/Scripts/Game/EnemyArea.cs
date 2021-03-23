using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArea : MonoBehaviour
{
    // Maybe make an entrance door and exit door?
    // Entrance door will remain active while exit will be deactivated?
    [SerializeField]
    GameObject entrance;
    [SerializeField]
    GameObject exit;


    // Maybe make a Transform array that can have multiple positions defined?
    // Then I can just get a random number for each enemy and have them spawn in different areas
    //[SerializeField]
    //Transform spawnPosition1;
    //[SerializeField]
    //Transform spawnPosition2;
    //[SerializeField]
    //Transform spawnPosition3;

    [SerializeField]
    private Transform[] spawnPositions;

    [SerializeField]
    GameObject enemyPrefab;

    public bool allEnemiesDefeated = false;

    private bool invokeRunning = false;

    void CheckEnemies()
    {
        if (Enemy.enemiesExisting > 0)
        {
            Debug.Log(Enemy.enemiesExisting.ToString() + " enemies remaining.");
            allEnemiesDefeated = false;
        }
        else
        {
            Debug.Log("All enemies defeated");
            allEnemiesDefeated = true;
            invokeRunning = false;
            GameManager.Instance.currentAreaCompleted = true;

            //entrance.SetActive(false);
            exit.SetActive(false);

            CancelInvoke(nameof(CheckEnemies));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered area");

            // Check to see if invoke is running
            if (invokeRunning == false)
            {
                // Check to see if the current (previous) area has been completed
                if (GameManager.Instance.currentAreaCompleted == true)
                {
                    // Check to see if this area is currently set as the current area
                    if (GameManager.Instance.currentArea != this)
                    {
                        GameManager.Instance.currentArea = this;
                        GameManager.Instance.currentAreaCompleted = false;

                        SpawnEnemies();

                        invokeRunning = true;
                        InvokeRepeating(nameof(CheckEnemies), 0.0f, 1.0f);
                    }
                    else
                    {
                        Debug.Log("This is area is already set as the current area!");
                    }
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
            if (allEnemiesDefeated == true)
            {
                Debug.Log("Player exited area and defeated all enemies!");
            }
            else
            {
                Debug.Log("Player still needs to defeat all enemies!");
            }
        }
    }

    void SpawnEnemies()
    {
        int randomInt = Random.Range(0, spawnPositions.Length);

        Debug.Log("Random Number = " + randomInt.ToString());


        Instantiate(enemyPrefab, spawnPositions[randomInt]);

        entrance.SetActive(true);
        exit.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider>().size);
    }
}
