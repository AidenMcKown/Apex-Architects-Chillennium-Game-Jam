using System.Collections;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{

    float timeStep = 0.01f;


    public IEnumerator Transition(GameObject player, GameObject lightManager)
    {
        Vector3 originalCameraPosition = Camera.main.transform.position;
        // float transitionSpeed = 0;
        float lerpAmount = 0f;
        Vector3 offsetVector = new(0, -40f, 30);
        while (Vector3.Distance(Camera.main.transform.position, player.transform.position - offsetVector) > 0.004f)
        {
            // Move the camera to the target position and rotation
            Camera.main.transform.position = Vector3.Lerp(originalCameraPosition, player.transform.position - offsetVector, lerpAmount);
            // Transition FOV from current to 20
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 20, lerpAmount);
            // Make the camera look towards a given position using the LookAt function
            Camera.main.transform.LookAt(player.transform.position);

            lerpAmount += 0.01f;

            yield return new WaitForSeconds(timeStep);
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
