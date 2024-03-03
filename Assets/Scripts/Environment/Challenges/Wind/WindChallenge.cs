using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindChallenge : MonoBehaviour
{

    Vector3 windDirection;
    float windForce;
    float angle;

    public Rigidbody playerRigidbody;

    void Start()
    {
        // Get the player's rigidbody
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        SetWindDirection();
        ApplyWindForce(windDirection, windForce);
    }

    void SetWindDirection()
    {
        // Set the wind direction
        angle += Time.deltaTime;
        Vector3 direction = new(Mathf.Cos(angle), 0, Mathf.Sin(angle));
        windDirection = direction;
    }

    void ApplyWindForce(Vector3 windDirection, float windForce)
    {

        if (EnvironmentEventManager.CurrentState == EnvironmentEventManager.State.Afternoon)
        {

            windForce = 300;
            // Apply wind force to the player
            playerRigidbody.AddForce(windDirection * windForce);

        }
        if (EnvironmentEventManager.CurrentState == EnvironmentEventManager.State.Night)
        {

            windForce = 500;
            // Apply wind force to the player
            playerRigidbody.AddForce(windDirection * windForce);

        }
        // Apply wind force to the player
    }
}
