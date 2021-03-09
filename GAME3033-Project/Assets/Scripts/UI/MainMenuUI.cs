using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private GameObject mainPanel;
    [SerializeField]
    private GameObject instructionsPanel;
    [SerializeField]
    private GameObject creditsPanel;

    public void InstructionsButton()
    {
        mainPanel.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    public void CreditsButton()
    {
        mainPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void InstructionsBackButton()
    {
        instructionsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void CreditsBackButton()
    {
        creditsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
}
