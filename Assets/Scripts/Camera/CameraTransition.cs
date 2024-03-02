using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{

    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float transitionSpeed;

    public static IEnumerator Transition()
    {
        while (Vector3.Distance(Camera.main.transform.position, new Vector3(0, 10, 0)) > 0.05f)
        {
            // Move the camera to the target position and rotation
            Camera.main.transform.SetPositionAndRotation(
                Vector3.Lerp(Camera.main.transform.position, new Vector3(-30, 42.1f, -30), 2 * Time.deltaTime),
                Quaternion.Lerp(Camera.main.transform.rotation, Quaternion.Euler(45, 45, 0), 2 * Time.deltaTime)
                );

            // Transition FOV from current to 10
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 10, 2 * Time.deltaTime);
            yield return null;
        }
    }
}
