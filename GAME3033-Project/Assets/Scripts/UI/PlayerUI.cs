using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text playerHealthText;
    [SerializeField]
    private TMP_Text playerDamageText;
    [SerializeField]
    private TMP_Text playerSpeedText;
    [SerializeField]
    private TMP_Text playerJumpHeightText;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        GameManager.Instance.reachedEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerDamageText.text = $"DMG: {playerController.playerDamage}";
        
        playerHealthText.text = $"HP: {playerController.currentHealth} / {playerController.maximumHealth}";

        // Set text to MAX
        if (playerController.maximumHealth >= 300)
        {
            playerHealthText.text = $"HP: {playerController.currentHealth} / MAX";
        }

        playerSpeedText.text = $"SPD: {playerController.playerSpeed}";

        // Set text to MAX
        if (playerController.playerSpeed >= 20.0f)
        {
            playerSpeedText.text = "SPD: MAX";
        }

        playerJumpHeightText.text = $"JMP: {playerController.jumpHeight}";

        // Set text to MAX
        if (playerController.jumpHeight >= 3.0f)
        {
            playerJumpHeightText.text = "JMP: MAX";
        }
    }
}
