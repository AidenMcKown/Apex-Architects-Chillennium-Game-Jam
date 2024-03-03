using System.Collections;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    SpawnManager spawnManager;

    public void StartGame()
    {
        CameraTransition cameraTransition = Camera.main.gameObject.GetComponent<CameraTransition>();

        // Spawn player at a random spawn point
        spawnManager.SpawnPlayer(player);

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

    public void OpenCredits(GameObject creditsMenu)
    {
        GameObject.FindGameObjectWithTag("MainMenu").SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void CloseCredits(GameObject mainMenu)
    {
        mainMenu.SetActive(true);
        GameObject.FindGameObjectWithTag("CreditsMenu").SetActive(false);
    }

}