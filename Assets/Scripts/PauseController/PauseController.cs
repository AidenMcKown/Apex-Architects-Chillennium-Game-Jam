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
        if (InputManager.GameIsPaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        InputManager.GameIsPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        InputManager.GameIsPaused = false;
    }
}