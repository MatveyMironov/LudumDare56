using UnityEngine;

public interface IHitable
{
    public void Hit(int damage, Vector3 from);
}
