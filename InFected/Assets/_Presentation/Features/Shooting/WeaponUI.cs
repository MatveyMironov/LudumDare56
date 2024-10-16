using InventorySystem;
using TMPro;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private PlayerWeaponHandler weaponHandler;
    [Space]
    [SerializeField] private TextMeshProUGUI ammoText;

    private void OnEnable()
    {
        weaponHandler.OnMagazineLoadChanged += DisplayAmmo;
        inventory.OnItemCountChanged += DisplayCurrentAmmunition;
    }

    private void OnDisable()
    {
        weaponHandler.OnMagazineLoadChanged -= DisplayAmmo;
        inventory.OnItemCountChanged -= DisplayCurrentAmmunition;
    }

    private void DisplayAmmo()
    {
        ammoText.text = $"{weaponHandler.LoadedAmmo}/{inventory.GetItemCount(weaponHandler.CurrentWeaponAmmunition)}";
    }

    private void DisplayCurrentAmmunition(ItemDataSO item)
    {
        if (item == weaponHandler.CurrentWeaponAmmunition)
        {
            DisplayAmmo();
        }
    }
}
