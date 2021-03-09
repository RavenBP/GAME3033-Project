using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    EnemyArea firstArea;
    [SerializeField]
    EnemyArea secondArea;

    public EnemyArea currentArea;
    public bool currentAreaCompleted = true;

    //GameObject secondArea;

    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {

    }
}
