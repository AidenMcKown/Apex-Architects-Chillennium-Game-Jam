using System.Collections;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        StartCoroutine(InitializeGame());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator InitializeGame()
    {
        CameraTransition cameraTransition = gameObject.AddComponent<CameraTransition>();

        // Spawn player and get new position
        GameObject player = GameObject.FindGameObjectWithTag("Player");

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        Transform? playerPosition = null;
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        // Wait until the player is spawned and the position is returned
        yield return new WaitUntil(() =>
        {
            playerPosition = HealthSystem.PlayerResetEvent?.Invoke(player);
            return playerPosition != null;
        });

        GameObject lightManager = GameObject.FindGameObjectWithTag("LightManager");

        // Transition from menu view to game view
        StartCoroutine(cameraTransition.Transition(playerPosition.position, lightManager));

        // Disable parent
        // Get the gameobject with the MainMenu tag and disable it
        GameObject.FindGameObjectWithTag("MainMenu").SetActive(false);
    }


}