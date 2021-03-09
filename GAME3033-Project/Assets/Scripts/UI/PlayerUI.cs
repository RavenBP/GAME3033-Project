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
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = "HP: " + playerController.currentHealth.ToString() + " / " + playerController.maximumHealth.ToString();

        playerDamageText.text = "DMG: " + playerController.playerDamage.ToString();

        playerSpeedText.text = "SPD: " + playerController.playerSpeed.ToString();

        playerJumpHeightText.text = "JMP: " + playerController.jumpHeight.ToString();
    }
}
