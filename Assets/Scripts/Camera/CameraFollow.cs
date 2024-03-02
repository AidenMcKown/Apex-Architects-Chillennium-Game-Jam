using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Make the camera follow the player
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        Camera.main.transform.position = playerPosition - new Vector3(0, -40f, 30);
    }
}
