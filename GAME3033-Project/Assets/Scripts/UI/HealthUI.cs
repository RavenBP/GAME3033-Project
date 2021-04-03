using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text playerHealthText;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        playerHealthText.text = $"HP: {playerController.currentHealth} / {playerController.maximumHealth}";

        // Set text to MAX
        if (playerController.maximumHealth >= 300)
        {
            playerHealthText.text = $"HP: {playerController.currentHealth} / MAX";
        }
    }
}

