using UnityEngine;

public class LightManager : MonoBehaviour
{

    float timeToRotate = EnvironmentEventManager.dayDuration;


    void Update()
    {
        if (EnvironmentEventManager.IsGameActive)
        {
            // Rotate the sun 2 degrees per second
            transform.Rotate(2 * Time.deltaTime * Vector3.right);
        }
    }
}
