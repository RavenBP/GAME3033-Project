using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int currentHealth = 100;
    public int maximumHealth;

    public static int enemiesExisting = 0;

    private void Start()
    {
        enemiesExisting++;

        //InvokeRepeating(nameof(NumEnemies), 0.0f, 1.0f);

        maximumHealth = EnemyStats.globalHealth;
        currentHealth = maximumHealth;
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
