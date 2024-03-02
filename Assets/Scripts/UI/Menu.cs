using System.Collections;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        CameraTransition cameraTransition = Camera.main.gameObject.GetComponent<CameraTransition>();

        // Find player game object in the scene
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Spawn player at a random spawn point
        HealthSystem.PlayerResetEvent?.Invoke(player);

        // Find light manager in the scene
        GameObject lightManager = GameObject.FindGameObjectWithTag("LightManager");

        // Start transition to the new camera position focusing on player
        StartCoroutine(cameraTransition.Transition(player, lightManager));

        // Disable the main menu
        GameObject.FindGameObjectWithTag("MainMenu").SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}