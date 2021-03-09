using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<PlayerController>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(playerTransform.position);
    }
}
