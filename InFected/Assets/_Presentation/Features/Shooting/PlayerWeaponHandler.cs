using System;
using UnityEngine;

public class PlayerWeaponHandler : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private Inventory inventory;

    [Space]
    [SerializeField] private float reloadingTime;

    [Header("Effects")]
    [SerializeField] private AudioSource reloadingSource;

    public int LoadedAmmo { get { return weapon.LoadedAmmo; } }
    public int MagazineCapacity { get { return weapon.MagazineCapacity; } }

    public event Action OnAmmoAmountChanged;

    private bool _isReloading;
    private float _reloadingTimer;

    private void Start()
    {
        ReloadWeapon();
    }

    private void Update()
    {
        if (_isReloading)
        {
            CountReloadingTimer();
        }
    }

    private void OnEnable()
    {
        weapon.OnAmmoAmountChanged += InvokeOnAmmoAmountChanged;
    }

    private void OnDisable()
    {
        weapon.OnAmmoAmountChanged -= InvokeOnAmmoAmountChanged;
    }

    public void PullWeaponTrigger()
    {
        if (_isReloading) { return; }

        weapon.PullTheTrigger();
    }

    public void ReleaseWeaponTrigger()
    {
        weapon.ReleaseTheTrigger();
        if (weapon.LoadedAmmo <= 0)
        {
            StartReloadingWeapon();
        }
    }

    public void StartReloadingWeapon()
    {
        if (_isReloading 
            || inventory.CurrentPistolCartridges <= 0 
            || weapon.MagazineCapacity - weapon.LoadedAmmo <= 0) 
        { return; }

        reloadingSource.Play();
        _isReloading = true;
    }

    private void CountReloadingTimer()
    {
        _reloadingTimer += Time.deltaTime;
        if (_reloadingTimer >= reloadingTime)
        {
            ReloadWeapon();
            reloadingSource.Stop();
            _isReloading = false;
            _reloadingTimer = 0f;
        }
    }

    private void ReloadWeapon()
    {
        int requiredAmmo = weapon.MagazineCapacity - weapon.LoadedAmmo;

        if (requiredAmmo <= inventory.CurrentPistolCartridges)
        {
            weapon.Reload(requiredAmmo);
            inventory.RemovePistolCartridges(requiredAmmo);
        }
        else
        {
            weapon.Reload(inventory.CurrentPistolCartridges);
            inventory.RemovePistolCartridges(inventory.CurrentPistolCartridges);
        }
    }

    private void InvokeOnAmmoAmountChanged()
    {
        OnAmmoAmountChanged?.Invoke();
    }
}
