using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] public float maxHealth = 100f;
    private float currentHealth;

    [Header("Events")]
    public static Func<GameObject, Transform> PlayerResetEvent;
    public static Action<float> PlayerDamageEvent;
    public static Action<float> PlayerHealEvent;

    void Awake()
    {
        PlayerDamageEvent += OnPlayerDamageEvent;
        PlayerHealEvent += OnPlayerHealEvent;
        currentHealth = maxHealth;
    }

    public void OnPlayerDamageEvent(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died");
        PlayerResetEvent?.Invoke(gameObject);
        currentHealth = maxHealth;
    }

    public void OnPlayerHealEvent(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
