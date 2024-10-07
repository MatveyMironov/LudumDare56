using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [field: SerializeField] public int MaxPistolCartridges { get; private set; }
    [field: SerializeField] public int DefaultPistolCartridges { get; private set; }
    public int CurrentPistolCartridges { get; private set; }

    public int CollectedSamples { get; private set; }

    public event Action OnPistolCartridgesAmountChanged;

    private void Awake()
    {
        ResetCurrentPistolCartridges();
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
    }
}
