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
        [SerializeField] private TextMeshProUGUI weaponNameText;

        private void Awake()
        {
            weaponNameText.text = "";
            inventoryAmmoText.text = "";
        }

        private void OnEnable()
        {
            weaponHandler.OnWeaponChanged += DisplayWeapon;
            weaponHandler.OnMagazineLoadChanged += DisplayMagazineLoad;
            inventory.OnItemCountChanged += DisplayInventoryAmmunition;
        }

        private void OnDisable()
        {
            weaponHandler.OnWeaponChanged -= DisplayWeapon;
            weaponHandler.OnMagazineLoadChanged -= DisplayMagazineLoad;
            inventory.OnItemCountChanged -= DisplayInventoryAmmunition;
        }

        private void DisplayWeapon()
        {
            magazineDisplayer.DisplayCapacity(weaponHandler.MagazineCapacity);
            DisplayInventoryAmmunition(weaponHandler.CurrentWeaponAmmunition);
            DisplayMagazineLoad();
        }

        private void DisplayMagazineLoad()
        {
            magazineDisplayer.DisplayLoad(weaponHandler.LoadedAmmo);
        }

        private void DisplayInventoryAmmunition(ItemDataSO item)
        {
            if (item == weaponHandler.CurrentWeaponAmmunition)
            {
                inventoryAmmoText.text = $"{inventory.GetItemCount(weaponHandler.CurrentWeaponAmmunition)}";
            }
        }
    }
}
