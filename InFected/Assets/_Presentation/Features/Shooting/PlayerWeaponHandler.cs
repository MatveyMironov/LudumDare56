using UnityEngine;

public class PlayerWeaponHandler : MonoBehaviour
{
    [field: SerializeField] public Weapon Weapon { get; private set; }
    [field: SerializeField] public Inventory Inventory { get; private set; }

    [Space]
    [SerializeField] private float reloadingTime;

    [Header("Effects")]
    [SerializeField] private AudioSource reloadingSource;

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

    public void PullWeaponTrigger()
    {
        if (_isReloading) { return; }

        Weapon.PullTheTrigger();
    }

    public void ReleaseWeaponTrigger()
    {
        Weapon.ReleaseTheTrigger();
        if (Weapon.LoadedAmmo <= 0)
        {
            StartReloadingWeapon();
        }
    }

    public void StartReloadingWeapon()
    {
        if (_isReloading 
            || Inventory.CurrentPistolCartridges <= 0 
            || Weapon.magazineCapacity - Weapon.LoadedAmmo <= 0) 
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
        int requiredAmmo = Weapon.magazineCapacity - Weapon.LoadedAmmo;

        if (requiredAmmo <= Inventory.CurrentPistolCartridges)
        {
            Weapon.Reload(requiredAmmo);
            Inventory.RemovePistolCartridges(requiredAmmo);
        }
        else
        {
            Weapon.Reload(Inventory.CurrentPistolCartridges);
            Inventory.RemovePistolCartridges(Inventory.CurrentPistolCartridges);
        }
    }
}
