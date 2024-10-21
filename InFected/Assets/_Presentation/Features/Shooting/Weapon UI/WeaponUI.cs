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
            inventoryAmmoText.text = "";
            weaponNameText.text = "";
        }

        private void OnEnable()
        {
            weaponHandler.OnWeaponChanged += DisplayWeaponName;
            weaponHandler.OnWeaponChanged += DisplayMagazineCapacity;
            weaponHandler.OnWeaponChanged += DisplayMagazineLoad;
            weaponHandler.OnWeaponChanged += DisplayInventoryAmmunition;
            weaponHandler.OnMagazineLoadChanged += DisplayMagazineLoad;
            inventory.OnItemCountChanged += DisplayItemCount;
        }

        private void OnDisable()
        {
            weaponHandler.OnWeaponChanged -= DisplayWeaponName;
            weaponHandler.OnWeaponChanged -= DisplayMagazineCapacity;
            weaponHandler.OnWeaponChanged -= DisplayMagazineLoad;
            weaponHandler.OnWeaponChanged -= DisplayInventoryAmmunition;
            weaponHandler.OnMagazineLoadChanged -= DisplayMagazineLoad;
            inventory.OnItemCountChanged -= DisplayItemCount;
        }

        private void DisplayWeaponName()
        {
            
        }

        private void DisplayMagazineCapacity()
        {
            magazineDisplayer.DisplayCapacity(weaponHandler.MagazineCapacity);
        }

        private void DisplayMagazineLoad()
        {
            magazineDisplayer.DisplayLoad(weaponHandler.LoadedAmmo);
            inventoryAmmoText.text = $"{inventory.GetItemCount(weaponHandler.CurrentWeaponAmmunition)}";
        }

        private void DisplayInventoryAmmunition()
        {
            DisplayItemCount(weaponHandler.CurrentWeaponAmmunition);
        }

        private void DisplayItemCount(ItemDataSO item)
        {
            if (item == weaponHandler.CurrentWeaponAmmunition)
            {
                DisplayMagazineLoad();
            }
        }
    }
}
