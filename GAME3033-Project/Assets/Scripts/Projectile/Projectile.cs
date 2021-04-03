using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 20.0f;
    [SerializeField]
    private float lifetime = 1.0f;

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

        yield return new WaitForSeconds(lifetime);

        // Destroy projectile
        Destroy(this.gameObject);
    }
}
