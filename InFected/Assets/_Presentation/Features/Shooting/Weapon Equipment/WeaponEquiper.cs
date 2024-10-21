using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class WeaponEquiper : MonoBehaviour
    {
        [Space]
        [SerializeField] private List<Weapon> weapons;

        [Space]
        [SerializeField] private float equipingTime;

        [Space]
        [SerializeField] private Transform weaponGrip;
        [SerializeField] private PlayerWeaponHandler weaponHandler;

        public int CurrentWeaponIndex { get; private set; } = -1;

        private void Start()
        {
            StartEquipingWeapon(0);
        }

        public void StartEquipingWeapon(int weaponIndex)
        {
            if (weaponIndex != CurrentWeaponIndex)
            {
                Weapon weapon = weapons[weaponIndex];

                if (weapon != null)
                {
                    StartCoroutine(EquipingWeapon(weapon));
                }

                CurrentWeaponIndex = weaponIndex;
            }
        }

        public void StartEquipingNextWeapon()
        {
            if (CurrentWeaponIndex >= weapons.Count - 1)
            {
                StartEquipingWeapon(0);
            }
            else
            {
                StartEquipingWeapon(CurrentWeaponIndex + 1);
            }
        }

        public void StartEquipingPreviousWeapon()
        {
            if (CurrentWeaponIndex <= 0)
            {
                StartEquipingWeapon(weapons.Count - 1);
            }
            else
            {
                StartEquipingWeapon(CurrentWeaponIndex - 1);
            }
        }

        private IEnumerator EquipingWeapon(Weapon weapon)
        {
            yield return new WaitForSeconds(equipingTime);

            weaponHandler.SetWeapon(weapon);
        }
    }
}
