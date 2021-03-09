using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private int damage = 10;

    private PlayerController playerController;

    private bool canAttack;
    private bool isRunning;


    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        canAttack = false;
        isRunning = false;
    }

    private void Update()
    {
        if (canAttack && isRunning == false)
        {
            InvokeRepeating("Attack", 0.0f, 2.0f);
            isRunning = true;
        }
        else if (canAttack == false && isRunning)
        {
            CancelInvoke("Attack");
            isRunning = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // TODO: Add functionality for enemy to continously attack.
            // Maybe add an invoke function here?
            // And CancelInvoke when TriggerExit?
            Debug.Log("Player entered attack radius");

            canAttack = true;

            //playerController.health -= damage;
            //Debug.Log("Player health: " + playerController.health.ToString());

            //if (playerController.health <= 0)
            //{
            //    SceneManager.LoadScene("ResultsScene");
            //}
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left attack radius");
            canAttack = false;
        }
    }

    private void Attack()
    {
        playerController.currentHealth -= damage;
        Debug.Log("Current player health: " + playerController.currentHealth.ToString());

        if (playerController.currentHealth <= 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene("ResultsScene");
        }
    }
}
