using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinHandler : MonoBehaviour
{
    bool canDoWin;
    void Start()
    {
        canDoWin = true;
    }

    void Update()
    {
        if (GameState.hasWon && canDoWin)
        {
            print(canDoWin);
            OnGameWin();
            canDoWin = false;
        }
    }

    void OnGameWin()
    {
        print("You Won!");
        EnvironmentEventManager.IsGameActive = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        InputManager.SwitchActionMap(InputManager.PlayerControls.UI);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1, UnityEngine.SceneManagement.LoadSceneMode.Single);
        // Unload the current scene
        // UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(0);
    }

}
