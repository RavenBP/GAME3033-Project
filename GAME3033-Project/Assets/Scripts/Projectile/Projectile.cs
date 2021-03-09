using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 20.0f;
    [SerializeField]
    private float lifetime = 2.0f;

    public Vector3 cameraForward;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireProjectile(cameraForward));

        GameObject player = GameObject.FindGameObjectWithTag("Player");
    }

    public IEnumerator FireProjectile(Vector3 camForward)
    {
        // Fire projectile towards camera direction
        gameObject.GetComponentInChildren<Rigidbody>().AddForce((cameraForward) * speed, ForceMode.Impulse);
        Debug.Log("Damage: " + damage.ToString());

        yield return new WaitForSeconds(lifetime);

        // Destroy projectile
        Destroy(this.gameObject);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    //if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Default"))
    //    //{
    //    //    Debug.Log("Projectile OnCollisionEnter");
    //    //}

    //    //if (collision.collider.CompareTag("Enemy"))
    //    //{
    //    //    collision.gameObject.GetComponent<Enemy>().health -= 10;
    //    //    Debug.Log(gameObject.name.ToString() + " health: " + collision.gameObject.GetComponent<Enemy>().health.ToString());

    //    //    // Enemy has no health remaining
    //    //    if (collision.gameObject.GetComponent<Enemy>().health <= 0)
    //    //    {
    //    //        // Destroy enemy
    //    //        Destroy(collision.gameObject);
    //    //    }

    //    //    // Destroy projectile
    //    //    Destroy(this.gameObject);
    //    //}
    //}
}
