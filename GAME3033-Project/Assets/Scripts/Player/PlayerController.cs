using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public int maximumHealth = 100;
    [SerializeField]
    public int playerDamage = 10;
    [SerializeField]
    public float playerSpeed = 2.0f;
    [SerializeField]
    public float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    private CharacterController controller;
    private InputManager inputManager;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraTransform;

    public int currentHealth;

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
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0.0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0.0f;
        move.Normalize();
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        if (inputManager.PlayerJumpedThisFrame() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (gamePaused == true)
        {
            if (GetComponentInChildren<CinemachineVirtualCamera>().enabled == true)
            {
                GetComponentInChildren<CinemachineVirtualCamera>().enabled = false;
            }
        }
        if (gamePaused == false)
        {
            if (GetComponentInChildren<CinemachineVirtualCamera>().enabled == false)
            {
                GetComponentInChildren<CinemachineVirtualCamera>().enabled = true;
            }
        }
    }
}
