using System.Collections;
using UnityEngine;

public class LightManager : MonoBehaviour
{

    float timeStep = 0.02f;
    float timeToRotate = 120;

    void Start()
    {
        // Rotate the sun
        RotateSun();
    }

    public void RotateSun()
    {
        StartCoroutine(RotateSunCoroutine());
    }

    // Coroutine to rotate the sun
    private IEnumerator RotateSunCoroutine()
    {
        while (EnvironmentEventManager.IsGameActive)
        {
            // Rotate the sun 2 degrees per second
            transform.Rotate(360 / timeToRotate * timeStep * Vector3.right);
            yield return new WaitForSeconds(timeStep);
        }

    }
}
