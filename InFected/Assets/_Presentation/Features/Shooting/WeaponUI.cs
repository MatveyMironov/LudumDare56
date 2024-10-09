using TMPro;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private PlayerWeaponHandler weaponHandler;
    [Space]
    [SerializeField] private TextMeshProUGUI ammoText;

    private void DisplayAmmo()
    {
        ammoText.text = $"{weaponHandler.Weapon.LoadedAmmo}/{inventory.CurrentPistolCartridges}";
    }

    private void OnEnable()
    {
        inventory.OnPistolCartridgesAmountChanged += DisplayAmmo;
        weaponHandler.Weapon.OnAmmoAmountChanged += DisplayAmmo;
    }

    private void OnDisable()
    {
        inventory.OnPistolCartridgesAmountChanged -= DisplayAmmo;
        weaponHandler.Weapon.OnAmmoAmountChanged -= DisplayAmmo;
    }
}
