using UnityEngine;

public class WaterDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Insta-kills the player
            HealthSystem.ApplyDamage(10000);
        }
    }
}
