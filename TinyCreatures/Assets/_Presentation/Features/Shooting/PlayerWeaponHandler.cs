using System;
using UnityEngine;

public class PlayerWeaponHandler : MonoBehaviour
{
    [field: SerializeField] public Weapon Weapon { get; private set; }
    [field: SerializeField] public Inventory Inventory { get; private set; }

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

        if (requiredAmmo <= Inventory.CurrentPistolCartridges)
        {
            Weapon.Reload(requiredAmmo);
            Inventory.RemovePistolCartridges(requiredAmmo);
        }
        else
        {
            Weapon.Reload(Inventory.CurrentPistolCartridges);
            Inventory.RemovePistolCartridges(Inventory.CurrentPistolCartridges);
        }
    }
}
