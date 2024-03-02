using UnityEngine;

public class Menu : MonoBehaviour
{

    public void StartGame()
    {
        print("Start Game");
    }

    public void QuitGame()
    {
        print("Quit Game");
        Application.Quit();
    }

}
