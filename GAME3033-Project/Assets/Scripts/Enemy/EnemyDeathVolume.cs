using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathVolume : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy.enemiesExisting--;
            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider>().size);
    }
}
