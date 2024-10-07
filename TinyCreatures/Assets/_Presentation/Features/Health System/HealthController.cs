using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [ContextMenuItem("Reset Health", "ResetHealth")]
    [SerializeField] private int defaultHealth;
    [field: SerializeField] public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }

    public event Action OnHealthChanged;
    public event Action OnHealthExpired;

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
            OnHealthExpired?.Invoke();
        }
    }

    private void ResetHealth()
    {
        CurrentHealth = defaultHealth;
        OnHealthChanged?.Invoke();
    }
}
