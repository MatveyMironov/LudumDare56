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
        ammoText.text = $"{weaponHandler.LoadedAmmo}/{weaponHandler.MagazineCapacity} {inventory.CurrentPistolCartridges}";
    }

    private void OnEnable()
    {
        inventory.OnPistolCartridgesAmountChanged += DisplayAmmo;
        weaponHandler.OnAmmoAmountChanged += DisplayAmmo;
    }

    private void OnDisable()
    {
        inventory.OnPistolCartridgesAmountChanged -= DisplayAmmo;
        weaponHandler.OnAmmoAmountChanged -= DisplayAmmo;
    }
}
