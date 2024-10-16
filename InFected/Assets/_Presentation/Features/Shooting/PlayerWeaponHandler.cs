using InventorySystem;
using System;
using UnityEngine;

public class PlayerWeaponHandler : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private Inventory inventory;

    [Space]
    [SerializeField] private float reloadingTime;

    [Header("Effects")]
    [SerializeField] private AudioSource weaponSource;
    [SerializeField] private AudioClip reloadingClip;

    public ItemDataSO CurrentWeaponAmmunition { get { return weapon.AmmunitionType; } }
    public int LoadedAmmo { get { return weapon.LoadedAmmo; } }
    public int MagazineCapacity { get { return weapon.MagazineCapacity; } }

    public event Action OnMagazineLoadChanged;

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
        weapon.OnMagazineLoadChanged += InvokeOnMagazineLoadChanged;
    }

    private void OnDisable()
    {
        weapon.OnMagazineLoadChanged -= InvokeOnMagazineLoadChanged;
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
            || inventory.GetItemCount(weapon.AmmunitionType) <= 0 
            || weapon.MagazineCapacity - weapon.LoadedAmmo <= 0) 
        { return; }

        weaponSource.PlayOneShot(reloadingClip);
        _isReloading = true;
    }

    private void CountReloadingTimer()
    {
        _reloadingTimer += Time.deltaTime;
        if (_reloadingTimer >= reloadingTime)
        {
            ReloadWeapon();
            weaponSource.Stop();
            _isReloading = false;
            _reloadingTimer = 0f;
        }
    }

    private void ReloadWeapon()
    {
        int requiredAmmunitionAmount = weapon.MagazineCapacity - weapon.LoadedAmmo;
        int availableAmmunitionAmount = inventory.GetItemCount(weapon.AmmunitionType);

        if (requiredAmmunitionAmount <= availableAmmunitionAmount)
        {
            inventory.RemoveItem(weapon.AmmunitionType, requiredAmmunitionAmount);
            weapon.Reload(requiredAmmunitionAmount);
        }
        else
        {
            weapon.Reload(availableAmmunitionAmount);
            inventory.RemoveItem(weapon.AmmunitionType, availableAmmunitionAmount);
        }
    }

    private void InvokeOnMagazineLoadChanged()
    {
        OnMagazineLoadChanged?.Invoke();
    }
}
