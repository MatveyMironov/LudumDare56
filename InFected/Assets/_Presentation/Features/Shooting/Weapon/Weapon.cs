using System;
using UnityEngine;

namespace WeaponSystem
{
    public abstract class Weapon : MonoBehaviour
    {
        [field: SerializeField] public WeaponDataSO WeaponData;

        public int LoadedAmmo { get; protected set; }
        public bool IsReadyToFire { get; protected set; }

        public event Action OnMagazineLoadChanged;

        protected abstract void Update();

        public abstract void PullTheTrigger();

        public abstract void ReleaseTheTrigger();

        public void Reload(int ammo)
        {
            if (LoadedAmmo + ammo >= WeaponData.WeaponParameters.MagazineCapacity)
            {
                LoadedAmmo = WeaponData.WeaponParameters.MagazineCapacity;
            }
            else
            {
                LoadedAmmo += ammo;
            }

            RaiseAmmoAmountEvent();
        }

        protected void RaiseAmmoAmountEvent()
        {
            OnMagazineLoadChanged?.Invoke();
        }

        [Serializable]
        public class WeaponParameters
        {
            [field: SerializeField] public int MagazineCapacity { get; private set; }
            [field: Tooltip("In degrees")]
            [field: SerializeField, Range(0, 90)] public float ShootingSpread { get; private set; }
        }
    }
}
