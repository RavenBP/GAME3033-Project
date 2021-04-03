using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject projectilePrefab;
    [SerializeField]
    Transform projectileRotation;
    [SerializeField]
    Transform projectileSocket;

    [SerializeField]
    private EnemyType enemyType;

    public int currentHealth = 100;
    public int maximumHealth;

    public static int enemiesExisting = 0;

    private Vector3 direction;
    private Transform playerTransform;

    private void Start()
    {
        // Increment number of total enemies
        enemiesExisting++;

        // Find player's transform
        playerTransform = FindObjectOfType<PlayerController>().gameObject.transform;

        // Set enemy's health
        maximumHealth = EnemyStats.globalHealth;

        switch (enemyType)
        {
            case EnemyType.MeleeEnemy:
                // No special values needed
                break;
            case EnemyType.ShootingEnemy:
                // Beging firing projectiles
                InvokeRepeating(nameof(FireProjectile), 0.0f, 2.0f);
                break;
            case EnemyType.SmallEnemy:
                // Lower health / Increase speed
                maximumHealth -= 50;
                GetComponent<NavMeshAgent>().speed = 8.0f;
                break;
        }

        // Set current health to full
        currentHealth = maximumHealth;
    }

    private void Update()
    {
        // Make projectile socket rotate towards player's transform
        projectileRotation.LookAt(playerTransform.transform);
    }

    private void FireProjectile()
    {
        Instantiate(projectilePrefab, projectileSocket.position, transform.rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
            // Lower health by projectile damage
            currentHealth -= collision.gameObject.GetComponentInParent<Projectile>().damage;

            // Destroy projectile
            Destroy(collision.gameObject);

            // Enemy has no health remaining
            if (currentHealth <= 0)
            {
                // Decrease amount of total enemies
                enemiesExisting--;
                // Destroy enemy
                Destroy(this.transform.parent.gameObject);
            }
        }
    }
}

public enum EnemyType
{
    MeleeEnemy,
    ShootingEnemy,
    SmallEnemy
}
