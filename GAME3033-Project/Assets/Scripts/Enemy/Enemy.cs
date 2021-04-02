using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject projectilePrefab;
    [SerializeField]
    Transform projectileSocket;

    public int currentHealth = 100;
    public int maximumHealth;

    public static int enemiesExisting = 0;

    private void Start()
    {
        enemiesExisting++;

        //InvokeRepeating(nameof(NumEnemies), 0.0f, 1.0f);

        Debug.Log("Enemy created");

        //StartCoroutine(FireProjectile());

        InvokeRepeating(nameof(FireProjectile), 0.0f, 2.0f);

        maximumHealth = EnemyStats.globalHealth;
        currentHealth = maximumHealth;
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
