using InventorySystem;
using System;
using System.Collections;
using UnityEngine;
using WeaponSystem;

public class PlayerWeaponHandler : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    [Space]
    [SerializeField] private float reloadingSpeed;

    [Header("Effects")]
    [SerializeField] private AudioSource weaponSource;
    [SerializeField] private AudioClip reloadingClip;

    private Weapon _weapon;

    public ItemDataSO CurrentWeaponAmmunition { get { return (_weapon != null) ? _weapon.WeaponData.AmmunitionType : null; } }
    public int LoadedAmmo { get { return _weapon.LoadedAmmo; } }
    public int MagazineCapacity { get { return _weapon.WeaponData.WeaponParameters.MagazineCapacity; } }

    public bool ReadyToUseWeapon { get; set; }

    public event Action OnWeaponChanged;
    public event Action OnMagazineLoadChanged;

    private bool _isReloading;
    private float _reloadingTimer;

    private void Update()
    {
        if (_isReloading)
        {
            CountReloadingTimer();
        }
    }

    public void SetWeapon(Weapon weapon)
    {
        _weapon = weapon;
        OnWeaponChanged?.Invoke();
        _weapon.OnMagazineLoadChanged += InvokeOnMagazineLoadChanged;
    }

    private void OnDisable()
    {
        if (_weapon != null)
        {
            _weapon.OnMagazineLoadChanged -= InvokeOnMagazineLoadChanged;
        }
    }

    public void PullWeaponTrigger()
    {
        if (_weapon == null) { return; }

        if (_isReloading) { return; }

        _weapon.PullTheTrigger();
    }

    public void ReleaseWeaponTrigger()
    {
        if (_weapon == null) { return; }

        _weapon.ReleaseTheTrigger();

        if (_weapon.LoadedAmmo <= 0)
        {
            StartReloadingWeapon();
        }
    }

    public void StartReloadingWeapon()
    {
        if (_weapon == null) { return; }

        if (_isReloading
            || inventory.GetItemCount(_weapon.WeaponData.AmmunitionType) <= 0
            || _weapon.WeaponData.WeaponParameters.MagazineCapacity - _weapon.LoadedAmmo <= 0)
        { return; }

        weaponSource.PlayOneShot(reloadingClip);
        _isReloading = true;
    }

    private void CountReloadingTimer()
    {
        _reloadingTimer += Time.deltaTime;
        if (_reloadingTimer >= reloadingSpeed)
        {
            ReloadWeapon();
            weaponSource.Stop();
            _isReloading = false;
            _reloadingTimer = 0f;
        }
    }

    private void ReloadWeapon()
    {
        int requiredAmmunitionAmount = _weapon.WeaponData.WeaponParameters.MagazineCapacity - _weapon.LoadedAmmo;
        int availableAmmunitionAmount = inventory.GetItemCount(_weapon.WeaponData.AmmunitionType);

        if (requiredAmmunitionAmount <= availableAmmunitionAmount)
        {
            inventory.RemoveItem(_weapon.WeaponData.AmmunitionType, requiredAmmunitionAmount);
            _weapon.Reload(requiredAmmunitionAmount);
        }
        else
        {
            _weapon.Reload(availableAmmunitionAmount);
            inventory.RemoveItem(_weapon.WeaponData.AmmunitionType, availableAmmunitionAmount);
        }
    }

    private void InvokeOnMagazineLoadChanged()
    {
        OnMagazineLoadChanged?.Invoke();
    }
}
