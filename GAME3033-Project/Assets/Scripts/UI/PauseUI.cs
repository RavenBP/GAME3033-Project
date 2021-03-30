using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PauseUI : MonoBehaviour
{
    [SerializeField]
    GameObject pausePanel;
    [SerializeField]
    PlayerController playerController;

    private InputManager inputManager;

    private void Start()
    {
        inputManager = InputManager.Instance;
    }

    private void Update()
    {
        if (inputManager.PlayerPaused() && pausePanel.activeSelf == false)
        {
            Debug.Log("Game paused");
            PauseGame();
        }
        else if (inputManager.PlayerPaused() && pausePanel.activeSelf == true)
        {
            Debug.Log("Game unpaused");
            UnPauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;

        pausePanel.SetActive(true);
        PlayerController.gamePaused = true;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1.0f;

        pausePanel.SetActive(false);
        PlayerController.gamePaused = false;
    }
}
