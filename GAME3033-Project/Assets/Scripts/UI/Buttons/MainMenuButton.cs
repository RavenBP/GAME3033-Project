using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        // Ensure time is set back to normal in case returning from Pause menu
        Time.timeScale = 1.0f;

        SceneManager.LoadScene("MainMenuScene");
    }
}
