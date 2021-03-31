using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;

    private void Update()
    {
        if (InputManager.Instance.PlayerShootingThisFrame() && PlayerController.gamePaused == false)
        {
            projectilePrefab.GetComponent<Projectile>().cameraForward = GetComponentInChildren<Camera>().transform.forward;
            projectilePrefab.GetComponent<Projectile>().damage = GetComponent<PlayerController>().playerDamage;

            Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        }
    }
}
