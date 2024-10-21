using InventorySystem;
using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(fileName = "NewWeaponData", menuName = "Weapon Data")]
    public class WeaponDataSO : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }

        [field: SerializeField] public Weapon WeaponPrefab { get; private set; }
        [field: SerializeField] public Weapon.WeaponParameters WeaponParameters { get; private set; }
        [field: SerializeField] public ItemDataSO AmmunitionType { get; private set; }

        [field: Tooltip("Seconds")]
        [field: SerializeField] public float BaseReloadingTime { get; private set; }
    }
}
