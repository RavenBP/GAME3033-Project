using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private int damage = 10;
    [SerializeField]
    private float attackSpeed = 1.5f;

    private PlayerController playerController;

    private bool canAttack;
    private bool isRunning;


    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        canAttack = false;
        isRunning = false;

        // Set enemy's damage
        damage = EnemyStats.globalDamage;
    }

    private void Update()
    {
        if (canAttack && isRunning == false)
        {
            InvokeRepeating("Attack", 0.0f, attackSpeed);
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
            //Debug.Log("Player entered attack radius");
            canAttack = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player left attack radius");
            canAttack = false;
        }
    }

    private void Attack()
    {
        // Decrease player's health
        playerController.currentHealth -= damage;

        // Player has no health remaining
        if (playerController.currentHealth <= 0)
        {
            // Prepare cursor for Results Scene
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene("ResultsScene");
        }
    }
}
