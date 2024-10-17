using InventorySystem;
using TMPro;
using UnityEngine;

namespace UI
{
    public class WeaponUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Inventory inventory;
        [SerializeField] private PlayerWeaponHandler weaponHandler;

        [Header("UI Elements")]
        [SerializeField] private LoadCapacityDisplayer magazineDisplayer;
        [SerializeField] private TextMeshProUGUI inventoryAmmoText;

        private void Start()
        {
            magazineDisplayer.DisplayCapacity(weaponHandler.MagazineCapacity);
        }

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
            magazineDisplayer.DisplayLoad(weaponHandler.LoadedAmmo);
            inventoryAmmoText.text = $"{inventory.GetItemCount(weaponHandler.CurrentWeaponAmmunition)}";
        }

        private void DisplayCurrentAmmunition(ItemDataSO item)
        {
            if (item == weaponHandler.CurrentWeaponAmmunition)
            {
                DisplayAmmo();
            }
        }
    }
}
