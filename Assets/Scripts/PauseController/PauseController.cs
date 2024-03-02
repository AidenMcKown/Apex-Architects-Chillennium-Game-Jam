using UnityEngine;

public class PauseController : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    public static bool gameIsPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
        }
        ManagePause();
    }

    public void ManagePause()
    {
        if (gameIsPaused)
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
        gameIsPaused = !gameIsPaused;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameIsPaused = !gameIsPaused;
    }


}
