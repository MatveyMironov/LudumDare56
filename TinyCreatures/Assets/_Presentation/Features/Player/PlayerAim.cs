using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidbody;
    [Space]
    [SerializeField] private float turningSpeed;
    [SerializeField] private bool turnsInstantly;

    private float aimAngle;

    private void FixedUpdate()
    {
        if (playerRigidbody.rotation != aimAngle)
        {
            if (turnsInstantly)
            {
                playerRigidbody.rotation = aimAngle;
            }
            else
            {
                playerRigidbody.rotation = Mathf.MoveTowardsAngle(playerRigidbody.rotation, aimAngle, turningSpeed * Time.fixedDeltaTime);
            }
        }
    }

    public void SetAim(Vector2 aimPosition)
    {
        Vector2 aimDirection = aimPosition - playerRigidbody.position;
        aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90.0f;
    }
}
