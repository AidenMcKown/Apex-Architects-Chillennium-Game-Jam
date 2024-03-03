using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("Health Bar Settings")]
    [SerializeField] Slider healthBarSlider;
    [SerializeField] float healthValueSmoothTime = 0.1f;
    float currentVelocity = 0f;

    void Update()
    {
        // Hide the health bar when the game is not active
        if (EnvironmentEventManager.IsGameActive)
            healthBarSlider.gameObject.SetActive(true);
        else
            healthBarSlider.gameObject.SetActive(false);
    }

    public void SetHealthBar(float targetHealthPercentage)
    {
        // Smoothly transition the health bar value to the target health percentage
        healthBarSlider.value = Mathf.SmoothDamp(healthBarSlider.value, targetHealthPercentage, ref currentVelocity, healthValueSmoothTime);
    }
}
