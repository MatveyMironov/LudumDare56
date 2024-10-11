using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [field: SerializeField] public int MagazineCapacity { get; private set; }
    public int LoadedAmmo { get; protected set; }
    public bool IsReadyToFire { get; protected set; }

    public event Action OnAmmoAmountChanged;

    protected abstract void Update();

    public abstract void PullTheTrigger();

    public abstract void ReleaseTheTrigger();

    public void Reload(int ammo)
    {
        if (LoadedAmmo + ammo >= MagazineCapacity)
        {
            LoadedAmmo = MagazineCapacity;
        }
        else
        {
            LoadedAmmo += ammo;
        }

        RaiseAmmoAmountEvent();
    }

    protected void RaiseAmmoAmountEvent()
    {
        OnAmmoAmountChanged?.Invoke();
    }
}
