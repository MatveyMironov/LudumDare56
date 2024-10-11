using Door;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [field: SerializeField] public int MaxPistolCartridges { get; private set; }
    [field: SerializeField] public int DefaultPistolCartridges { get; private set; }

    public int CurrentPistolCartridges { get; private set; }
    public int CollectedSamples { get; private set; }
    public List<KeyCardDataSO> KeyCards { get; private set; } = new();

    public event Action OnPistolCartridgesAmountChanged;
    public event Action OnCollectedSamplesChanged;

    private void Awake()
    {
        ResetCurrentPistolCartridges();
        OnCollectedSamplesChanged?.Invoke();
    }

    public void AddPistolCartridges(int amount)
    {
        if (CurrentPistolCartridges + amount >= MaxPistolCartridges)
        {
            CurrentPistolCartridges = MaxPistolCartridges;
        }
        else
        {
            CurrentPistolCartridges += amount;
        }

        OnPistolCartridgesAmountChanged?.Invoke();
    }

    public void RemovePistolCartridges(int amount)
    {
        if (CurrentPistolCartridges <= amount)
        {
            CurrentPistolCartridges = 0;
        }
        else
        {
            CurrentPistolCartridges -= amount;
        }

        OnPistolCartridgesAmountChanged?.Invoke();
    }

    private void ResetCurrentPistolCartridges()
    {
        CurrentPistolCartridges = DefaultPistolCartridges;
    }

    public void AddSamples(int amount)
    {
        CollectedSamples += amount;
        OnCollectedSamplesChanged?.Invoke();
    }

    public void RemoveSamples(int amount)
    {
        if (CollectedSamples < amount)
        {
            CollectedSamples = 0;
        }
        else
        {
            CollectedSamples -= amount;
        }

        OnCollectedSamplesChanged?.Invoke();
    }

    public void AddKeyCard(KeyCardDataSO keyCard)
    {
        KeyCards.Add(keyCard);
    }
}
