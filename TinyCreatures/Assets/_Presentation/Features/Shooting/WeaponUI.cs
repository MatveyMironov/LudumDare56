using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private PlayerWeaponHandler weaponHandler;
    [Space]
    [SerializeField] private TextMeshProUGUI ammoText;

    private void DisplayAmmo()
    {
        ammoText.text = $"{weaponHandler.Weapon.LoadedAmmo}/{weaponHandler.AvailableAmmo}";
    }

    private void OnEnable()
    {
        weaponHandler.OnAvailableAmmoAmountChanged += DisplayAmmo;
        weaponHandler.Weapon.OnAmmoAmountChanged += DisplayAmmo;
    }

    private void OnDisable()
    {
        weaponHandler.OnAvailableAmmoAmountChanged -= DisplayAmmo;
        weaponHandler.Weapon.OnAmmoAmountChanged -= DisplayAmmo;
    }
}
