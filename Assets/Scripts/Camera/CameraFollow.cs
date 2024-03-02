using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float cameraFollowSmoothTime = 0.15f;
    [SerializeField] Vector3 cameraOffset = new Vector3(0, 40f, -30f);
    Vector3 cameraVelocity = Vector3.zero;

    void LateUpdate()
    {
        // Get the target camera position
        Vector3 targetPosition = player.position + cameraOffset;

        // Smoothly transition the camera to the target position
        Vector3 currentPosition = Vector3.SmoothDamp(Camera.main.transform.position, targetPosition, ref cameraVelocity, cameraFollowSmoothTime);
        Camera.main.transform.position = currentPosition;
    }
}
