using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pickup : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private bool randomizePickup = false;
    [SerializeField]
    private PickupType pickupType;

    [Header("References")]
    [SerializeField]
    private TMP_Text pickupText;

    public static int pickupsExisting;

    private PickupSounds pickupSounds;

    private void Start()
    {
        pickupSounds = GameObject.FindGameObjectWithTag("PickupSounds").GetComponent<PickupSounds>();

        // If this pickup is randomized
        if (randomizePickup == true)
        {
            int randomInt = Random.Range(1, 100);

            if (randomInt >= 0 && randomInt <= 24)
            {
                pickupType = PickupType.Health;
            }
            else if (randomInt >= 25 && randomInt <= 49)
            {
                pickupType = PickupType.Damage;
            }
            else if (randomInt >= 50 && randomInt <= 74)
            {
                pickupType = PickupType.Speed;
            }
            else if (randomInt >= 75)
            {
                pickupType = PickupType.Jump;
            }

            //Debug.Log(this.gameObject.name.ToString() + " randomized to: " + pickupType.ToString());
        }

        pickupText.text = pickupType.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player got pickup");

            switch (pickupType)
            {
                case PickupType.Health:
                    // Increase player's maximum health
                    int newHealth = other.gameObject.GetComponent<PlayerController>().maximumHealth += 10;
                    // Clamp player's health
                    other.gameObject.GetComponent<PlayerController>().maximumHealth = Mathf.Clamp(newHealth, other.gameObject.GetComponent<PlayerController>().maximumHealth, 300);
                    // Restore player's health
                    other.gameObject.GetComponent<PlayerController>().currentHealth = other.gameObject.GetComponent<PlayerController>().maximumHealth;

                    pickupSounds.PlayHealthSound();

                    break;
                case PickupType.Damage:
                    // Increase player's damage
                    other.gameObject.GetComponent<PlayerController>().playerDamage += 5;

                    pickupSounds.PlayDamageSound();

                    break;
                case PickupType.Speed:
                    // Increase player's speed
                    float newSpeed = other.gameObject.GetComponent<PlayerController>().playerSpeed += 1.0f;
                    // Clamp player's speed
                    other.gameObject.GetComponent<PlayerController>().playerSpeed = Mathf.Clamp(newSpeed, other.gameObject.GetComponent<PlayerController>().playerSpeed, 20.0f);

                    pickupSounds.PlaySpeedSound();

                    break;
                case PickupType.Jump:
                    // Increase player's jump height
                    float newJumpHeight = other.gameObject.GetComponent<PlayerController>().jumpHeight += 0.2f;
                    // Clamp player's jump height
                    other.gameObject.GetComponent<PlayerController>().jumpHeight = Mathf.Clamp(newJumpHeight, other.gameObject.GetComponent<PlayerController>().jumpHeight, 3.0f);

                    pickupSounds.PlayJumpSound();

                    break;
            }

            pickupsExisting--;
            Destroy(this.gameObject);
        }
    }
}