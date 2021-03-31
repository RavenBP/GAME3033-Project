using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    [Tooltip("The maximum health (health pool) the player has.")]
    [SerializeField]
    public int maximumHealth = 100;
    [Tooltip("The amount of damage the player will do with their projectiles.")]
    [SerializeField]
    public int playerDamage = 10;
    [Tooltip("The speed of the player.")]
    [SerializeField]
    public float playerSpeed = 2.0f;
    [Tooltip("The height the player will jump.")]
    [SerializeField]
    public float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    public int currentHealth;

    [Header("References")]
    [SerializeField]
    GameObject statsUI;
    [SerializeField]
    GameObject healthUI;

    private CharacterController controller;
    private InputManager inputManager;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraTransform;


    public static bool gamePaused = false;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;

        currentHealth = maximumHealth;
    }

    void Update()
    {
        // Set whether or not player is grounded
        groundedPlayer = controller.isGrounded;

        // Remove y velocity if player is grounded
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Player movement
        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0.0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0.0f;
        move.Normalize();
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Make player jump
        if (inputManager.PlayerJumpedThisFrame() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // Display player's stats
        DisplayStats();

        // Check to see if game is paused
        CheckPaused();
    }

    public void CheckPaused()
    {
        if (gamePaused == true)
        {
            if (GetComponentInChildren<CinemachineVirtualCamera>().enabled == true)
            {
                GetComponentInChildren<CinemachineVirtualCamera>().enabled = false;
            }
        }
        else if (gamePaused == false)
        {
            if (GetComponentInChildren<CinemachineVirtualCamera>().enabled == false)
            {
                GetComponentInChildren<CinemachineVirtualCamera>().enabled = true;
            }
        }
    }

    public void DisplayStats()
    {
        if (inputManager.PlayerViewingStats() && gamePaused == false)
        {
            statsUI.SetActive(!statsUI.activeSelf);
            healthUI.SetActive(!healthUI.activeSelf);
        }
    }
}
