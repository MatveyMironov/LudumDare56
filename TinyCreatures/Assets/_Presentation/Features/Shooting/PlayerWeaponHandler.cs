using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponHandler : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private int availableAmmo;

    public void PullTheTrigger()
    {
        weapon.PullTheTrigger();
    }

    public void ReleaseTheTrigger()
    {
        weapon.ReleaseTheTrigger();
    }

    public void Reload()
    {
        int requiredAmmo = weapon.magazineCapacity - weapon.LoadedAmmo;
        if (requiredAmmo <= 0)
        { return; }

        if (requiredAmmo <= availableAmmo)
        {
            weapon.Reload(requiredAmmo);
            availableAmmo -= requiredAmmo;
        }
        else
        {
            weapon.Reload(availableAmmo);
            availableAmmo = 0;
        }
    }
}
