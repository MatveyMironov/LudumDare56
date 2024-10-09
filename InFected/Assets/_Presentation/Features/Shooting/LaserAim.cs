using UnityEngine;

public class LaserAim : MonoBehaviour
{
    [SerializeField] private Transform muzzle;
    [SerializeField] private LayerMask hitableLayers;
    [SerializeField] private LineRenderer laserEffect;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(muzzle.position, muzzle.up, 100, hitableLayers);
        Vector3 loacalPosition = muzzle.InverseTransformPoint(hit.point);
        laserEffect.SetPosition(1, loacalPosition);
    }
}
