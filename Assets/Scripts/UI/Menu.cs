using UnityEngine;

public class Menu : MonoBehaviour
{

    public void StartGame()
    {
        // print("Start Game");
        CameraTransition cameraTransition = gameObject.AddComponent<CameraTransition>();
        // Transition from menu view to game view
        Vector3 lookAtPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        GameObject lightManager = GameObject.FindGameObjectWithTag("LightManager");
        StartCoroutine(cameraTransition.Transition(lookAtPosition, lightManager));

        // Disable parent
        // Get the gameobject with the MainMenu tag and disable it
        GameObject.FindGameObjectWithTag("MainMenu").SetActive(false);
    }

    public void QuitGame()
    {
        // print("Quit Game");
        Application.Quit();
    }

}
