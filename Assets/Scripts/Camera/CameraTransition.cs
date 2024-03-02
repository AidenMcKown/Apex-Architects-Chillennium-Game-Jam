using System.Collections;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{

    [SerializeField] private Vector3 targetPosition;

    public IEnumerator Transition(Vector3 playerPosition)
    {
        float transitionSpeed = 2;
        while (Vector3.Distance(Camera.main.transform.position, playerPosition - new Vector3(30, -40f, 30)) > 0.001f)
        {
            // Move the camera to the target position and rotation
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, playerPosition - new Vector3(30, -40f, 30), transitionSpeed * Time.deltaTime);

            // Make the camera look towards a given position using the LookAt function
            Camera.main.transform.LookAt(playerPosition);

            // Transition FOV from current to 10
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 10, transitionSpeed * Time.deltaTime);
            transitionSpeed += 0.01f;
            yield return null;
        }
        // print("Transition complete");
        Camera.main.GetComponent<CameraFollow>().enabled = true;
        Camera.main.GetComponent<CameraTransition>().enabled = false;
    }
}
