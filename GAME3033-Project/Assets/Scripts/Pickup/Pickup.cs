using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    private bool randomizePickup = false;
    [SerializeField]
    private PickupType pickupType;

    public static int pickupsExisting;

    private void Start()
    {
        //pickupsExisting++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player got pickup");

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

                Debug.Log("Pickup randomized to: " + pickupType);
            }

            switch (pickupType)
            {
                case PickupType.Health:
                    other.gameObject.GetComponent<PlayerController>().maximumHealth += 10;
                    other.gameObject.GetComponent<PlayerController>().currentHealth = other.gameObject.GetComponent<PlayerController>().maximumHealth;
                    break;
                case PickupType.Damage:
                    other.gameObject.GetComponent<PlayerController>().playerDamage += 5;
                    break;
                case PickupType.Speed:
                    other.gameObject.GetComponent<PlayerController>().playerSpeed += 2.0f;
                    break;
                case PickupType.Jump:
                    other.gameObject.GetComponent<PlayerController>().jumpHeight += 1.0f;
                    break;
            }

            pickupsExisting--;
            Destroy(this.gameObject);
        }
    }
}