using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        // If the game has not started, do not allow the player to pause
        if (!InputManager.HasGameStarted) return;

        ManagePause();
    }

    public void ManagePause()
    {
        if (EnvironmentEventManager.IsGameActive)
        {
            // Game is active
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        else
        {
            // Game is paused
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        // print(Time.timeScale);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        EnvironmentEventManager.IsGameActive = true;
        InputManager.SwitchActionMap(InputManager.PlayerControls.Player);
    }
}