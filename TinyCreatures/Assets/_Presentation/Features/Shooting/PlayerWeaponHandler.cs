using System;
using UnityEngine;

public class PlayerWeaponHandler : MonoBehaviour
{
    [field: SerializeField] public Weapon Weapon { get; private set; }
    [field: SerializeField] public int AvailableAmmo { get; private set; }

    public event Action OnAvailableAmmoAmountChanged;

    private void Start()
    {
        ReloadWeapon();
    }

    public void PullWeaponTrigger()
    {
        Weapon.PullTheTrigger();
    }

    public void ReleaseWeaponTrigger()
    {
        Weapon.ReleaseTheTrigger();
    }

    public void ReloadWeapon()
    {
        int requiredAmmo = Weapon.magazineCapacity - Weapon.LoadedAmmo;
        if (requiredAmmo <= 0)
        { return; }

        if (requiredAmmo <= AvailableAmmo)
        {
            Weapon.Reload(requiredAmmo);
            AvailableAmmo -= requiredAmmo;
        }
        else
        {
            Weapon.Reload(AvailableAmmo);
            AvailableAmmo = 0;
        }

        OnAvailableAmmoAmountChanged?.Invoke();
    }
}
