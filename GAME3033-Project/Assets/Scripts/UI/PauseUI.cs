using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PauseUI : MonoBehaviour
{
    [SerializeField]
    GameObject pausePanel;
    [SerializeField]
    GameObject statsPanel;
    [SerializeField]
    GameObject healthPanel;

    private InputManager inputManager;

    private void Start()
    {
        inputManager = InputManager.Instance;
    }

    private void Update()
    {
        if (inputManager.PlayerPaused() && pausePanel.activeSelf == false)
        {
            PauseGame();
        }
        else if (inputManager.PlayerPaused() && pausePanel.activeSelf == true)
        {
            UnPauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;

        statsPanel.SetActive(false);
        healthPanel.SetActive(false);
        pausePanel.SetActive(true);
        PlayerController.gamePaused = true;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1.0f;

        pausePanel.SetActive(false);
        healthPanel.SetActive(true);
        PlayerController.gamePaused = false;
    }
}
