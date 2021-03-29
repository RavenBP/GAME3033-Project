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

    private bool damageNeedsUpdate = true;
    private bool speedNeedsUpdate = true;
    private bool jumpHeightNeedsUpdate = true;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        playerDamageText.text = "DMG: " + playerController.playerDamage.ToString();
        
        playerHealthText.text = "HP: " + playerController.currentHealth.ToString() + " / " + playerController.maximumHealth.ToString();

        // Set text to MAX
        if (playerController.maximumHealth >= 300)
        {
            playerHealthText.text = "HP: " + playerController.currentHealth.ToString() + " / MAX";
        }

        playerSpeedText.text = "SPD: " + playerController.playerSpeed.ToString();

        // Set text to MAX
        if (playerController.playerSpeed >= 20.0f)
        {
            playerSpeedText.text = "SPD: MAX";
        }

        playerJumpHeightText.text = "JMP: " + playerController.jumpHeight.ToString();

        // Set text to MAX
        if (playerController.jumpHeight >= 3.0f)
        {
            playerJumpHeightText.text = "JMP: MAX";
        }
    }
}
