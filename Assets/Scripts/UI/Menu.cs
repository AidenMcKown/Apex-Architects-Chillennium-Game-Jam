using UnityEngine;

public class Menu : MonoBehaviour
{

    public void StartGame(Transform parent)
    {
        print("Start Game");
        // Transition from menu view to game view
        StartCoroutine(CameraTransition.Transition());
        // Disable parent
        parent.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        print("Quit Game");
        Application.Quit();
    }

}
