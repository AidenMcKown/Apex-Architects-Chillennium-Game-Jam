using System.Collections;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{

    public IEnumerator Transition(Vector3 playerPosition, GameObject lightManager)
    {
        float transitionSpeed = 0;
        Vector3 offsetVector = new(0, -40f, 30);
        while (Vector3.Distance(Camera.main.transform.position, playerPosition - offsetVector) > 0.001f)
        {
            // Move the camera to the target position and rotation
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, playerPosition - offsetVector, transitionSpeed * Time.deltaTime);

            // Make the camera look towards a given position using the LookAt function
            Camera.main.transform.LookAt(playerPosition);

            // Transition FOV from current to 10
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 20, transitionSpeed * Time.deltaTime);
            transitionSpeed += 0.01f;
            yield return null;
        }
        // print("Transition complete");
        Camera.main.GetComponent<CameraFollow>().enabled = true;

        // Enable player action map and officially start the game
        InputManager.HasGameStarted = true;
        InputManager.SwitchActionMap(InputManager.PlayerControls.Player);

        // Disable the camera transition script
        lightManager.GetComponent<LightManager>().enabled = true;
        EnvironmentEventManager.IsGameActive = true;
        Camera.main.GetComponent<CameraTransition>().enabled = false;
    }
}
