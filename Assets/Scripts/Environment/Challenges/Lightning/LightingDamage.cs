using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingDamage : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Insta-kills the player
            HealthSystem.ApplyDamage(10);
        }
    }
}
