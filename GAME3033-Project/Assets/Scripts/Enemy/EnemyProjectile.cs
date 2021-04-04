using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.1f;
    [SerializeField]
    private float lifetime = 5.0f;

    public int damage = EnemyStats.globalDamage / 2;

    private GameObject player;
    private AudioSource audioSource;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(FireProjectile(player.transform.position));
    }

    public IEnumerator FireProjectile(Vector3 camForward)
    {
        gameObject.GetComponentInChildren<Rigidbody>().AddForce((transform.forward) * speed, ForceMode.Impulse);
        audioSource.Play();

        yield return new WaitForSeconds(lifetime);

        // Destroy projectile
        Destroy(this.transform.parent.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            // Destroy the projectile
            Destroy(this.transform.parent.gameObject);
        }

        if (collision.collider.CompareTag("Player"))
        {
            // Decrease player's health
            collision.gameObject.GetComponent<PlayerController>().currentHealth -= damage;

            // Enemy has no health remaining
            if (collision.gameObject.GetComponent<PlayerController>().currentHealth <= 0)
            {
                SceneManager.LoadScene("ResultsScene");
            }

            //Destroy projectile
            Destroy(this.transform.parent.gameObject);
        }
    }
}
