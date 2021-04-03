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
        enemiesExisting++;

        playerTransform = FindObjectOfType<PlayerController>().gameObject.transform;

        maximumHealth = EnemyStats.globalHealth;

        switch (enemyType)
        {
            case EnemyType.MeleeEnemy:
                break;
            case EnemyType.ShootingEnemy:
                InvokeRepeating(nameof(FireProjectile), 0.0f, 2.0f);
                break;
            case EnemyType.SmallEnemy:
                maximumHealth -= 50;
                GetComponent<NavMeshAgent>().speed = 8.0f;
                break;
        }

        currentHealth = maximumHealth;
    }

    private void Update()
    {
        projectileRotation.LookAt(playerTransform.transform);
    }

    private void FireProjectile()
    {
        Debug.Log("Projectile Fired!");
        Instantiate(projectilePrefab, projectileSocket.position, transform.rotation);
    }

    void NumEnemies()
    {
        Debug.Log("NumEnemies: " + enemiesExisting.ToString());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
            currentHealth -= collision.gameObject.GetComponentInParent<Projectile>().damage;
            Debug.Log(gameObject.name.ToString() + " health: " + currentHealth.ToString());

            // Destroy projectile
            Destroy(collision.gameObject);

            // Enemy has no health remaining
            if (currentHealth <= 0)
            {
                // Destroy enemy
                enemiesExisting--;
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
