using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private HealthController healthController;

    public event Action OnPlayerDeath;

    private void OnEnable()
    {
        healthController.OnHealthExpired += Death;
    }

    private void OnDisable()
    {
        healthController.OnHealthExpired -= Death;
    }

    private void Death()
    {
        OnPlayerDeath?.Invoke();
    }
}
