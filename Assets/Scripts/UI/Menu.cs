using UnityEngine;

public class Menu : MonoBehaviour
{

    public void StartGame()
    {
        // print("Start Game");
        CameraTransition CameraTransition = new();
        // Transition from menu view to game view
        Vector3 lookAtPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        StartCoroutine(CameraTransition.Transition(lookAtPosition));

        // Disable parent
        // Get the gameobject with the mainmenu tag and disable it
        GameObject.FindGameObjectWithTag("MainMenu").SetActive(false);
    }

    public void QuitGame()
    {
        // print("Quit Game");
        Application.Quit();
    }

}
