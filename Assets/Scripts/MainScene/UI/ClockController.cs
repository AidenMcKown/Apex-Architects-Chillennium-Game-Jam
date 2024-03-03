using UnityEngine;

public class ClockController : MonoBehaviour
{
    void Update()
    {
        if (EnvironmentEventManager.IsGameActive)
        {
            transform.Rotate(-360 / EnvironmentEventManager.dayDuration * Time.deltaTime * Vector3.forward);
        }
    }
}
