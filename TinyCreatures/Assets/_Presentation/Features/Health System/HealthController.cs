using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [ContextMenuItem("Reset Health", "ResetHealth")]
    [SerializeField] private int defaultHealth;

    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }

    public event Action OnHealthChanged;

    private void Awake()
    {
        ResetHealth();
    }

    public void AddHealth(int health)
    {
        if (CurrentHealth + health >= MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        else
        {
            CurrentHealth += health;
        }

        OnHealthChanged?.Invoke();
    }

    public void SubtractHealth(int health)
    {
        if (CurrentHealth <= health)
        {
            CurrentHealth = 0;
        }
        else
        {
            CurrentHealth -= health;
        }

        OnHealthChanged?.Invoke();

        if (CurrentHealth <= 0)
        {
            Death();
        }
    }

    private void ResetHealth()
    {
        MaxHealth = defaultHealth;
        CurrentHealth = defaultHealth;
        OnHealthChanged?.Invoke();
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
