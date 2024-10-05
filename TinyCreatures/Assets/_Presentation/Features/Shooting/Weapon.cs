using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [field: SerializeField] public int magazineCapacity { get; private set; }
    public int LoadedAmmo { get; protected set; }
    public bool IsReadyToFire { get; protected set; }

    protected abstract void Update();

    public abstract void PullTheTrigger();

    public abstract void ReleaseTheTrigger();

    public void Reload(int ammo)
    {
        if (LoadedAmmo + ammo >= magazineCapacity)
        {
            LoadedAmmo = magazineCapacity;
        }
        else
        {
            LoadedAmmo += ammo;
        }
    }
}
