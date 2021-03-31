using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text currentHealthText;
    [SerializeField]
    TMP_Text maximumHealthText;

    private Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = this.gameObject.transform.parent.gameObject.GetComponentInChildren<Enemy>();

        currentHealthText.text = enemy.currentHealth.ToString();
        maximumHealthText.text = enemy.maximumHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = Camera.main.transform.forward;

        currentHealthText.text = enemy.currentHealth.ToString();
    }
}
