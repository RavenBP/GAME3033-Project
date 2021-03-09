using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    public static int enemiesExisting = 0;

    private void Start()
    {
        enemiesExisting++;

        //InvokeRepeating(nameof(NumEnemies), 0.0f, 1.0f);
    }

    void NumEnemies()
    {
        Debug.Log("NumEnemies: " + enemiesExisting.ToString());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
            health -= collision.gameObject.GetComponentInParent<Projectile>().damage;
            Debug.Log(gameObject.name.ToString() + " health: " + health.ToString());

            // Destroy projectile
            Destroy(collision.gameObject);

            // Enemy has no health remaining
            if (health <= 0)
            {
                // Destroy enemy
                enemiesExisting--;
                Destroy(this.transform.parent.gameObject);
            }
        }
    }
}
