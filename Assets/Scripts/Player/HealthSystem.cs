using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] HealthBar healthBar;
    [SerializeField] public float maxHealth = 100f;
    public static float currentHealth;

    [Header("Events")]
    public static Func<GameObject, Transform> PlayerResetEvent;
    public static event Action<float> PlayerDamageEvent;
    public static event Action<float> PlayerHealEvent;

    void Awake()
    {
        currentHealth = maxHealth;

        PlayerDamageEvent += OnPlayerDamageEvent;
        PlayerHealEvent += OnPlayerHealEvent;
    }

    void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.SetHealthBar(currentHealth / maxHealth);
    }

    public static void ApplyDamage(float damageAmount)
    {
        PlayerDamageEvent?.Invoke(damageAmount);
    }

    private void OnPlayerDamageEvent(float damageAmount)
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

    public static void ApplyHeal(float healAmount)
    {
        PlayerHealEvent?.Invoke(healAmount);
    }

    private void OnPlayerHealEvent(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    void OnDisable()
    {
        PlayerDamageEvent -= OnPlayerDamageEvent;
        PlayerHealEvent -= OnPlayerHealEvent;
    }
}
