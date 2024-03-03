using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeDamage : MonoBehaviour
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
