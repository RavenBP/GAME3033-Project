using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArea : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private int spawnPercentage = 85;

    [Header("References")]
    [SerializeField]
    GameObject entrance;
    [SerializeField]
    GameObject exit;

    [SerializeField]
    AudioClip[] audioClips;

    [SerializeField]
    private Transform[] spawnPositions;

    [SerializeField]
    GameObject meleeEnemyPrefab;
    [SerializeField]
    GameObject shootingEnemyPrefab;
    [SerializeField]
    GameObject smallEnemyPrefab;

    public bool allEnemiesDefeated = false;

    private bool invokeRunning = false;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
            audioSource.clip = audioClips[1];
            audioSource.Play();

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

                        Enemy.enemiesExisting = 0;

                        SpawnEnemies();
                        audioSource.clip = audioClips[0];
                        audioSource.Play();

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
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            int randomNum = Random.Range(0, 100);

            if (randomNum >= (100 - spawnPercentage))
            {
                int randNum = Random.Range(0, 100);
                if (randNum >= 0 && randNum <= 40)
                {
                    Instantiate(meleeEnemyPrefab, spawnPositions[i]);
                }
                else if (randNum >= 41 && randNum <= 80)
                {
                    Instantiate(shootingEnemyPrefab, spawnPositions[i]);
                }
                else if (randNum >= 81 && randNum <= 100)
                {
                    Instantiate(smallEnemyPrefab, spawnPositions[i]);
                }
            }
        }



        entrance.SetActive(true);
        exit.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider>().size);
    }
}
