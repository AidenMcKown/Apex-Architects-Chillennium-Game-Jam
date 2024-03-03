using System.Collections;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject gameOverMenu;
    bool canDie = true;


    void Update()
    {
        if (HealthSystem.currentHealth <= 0 && canDie)
        {
            OnGameOver();
            canDie = false;
        }
    }

    public void OnGameOver()
    {
        print("Game Over");
        EnvironmentEventManager.IsGameActive = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Camera.main.GetComponent<CameraFollow>().enabled = false;
        StartCoroutine(GameOverCoroutine());
    }

    IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(1f);
        Destroy(player);
        gameOverMenu.SetActive(true);
    }

    public void Retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
