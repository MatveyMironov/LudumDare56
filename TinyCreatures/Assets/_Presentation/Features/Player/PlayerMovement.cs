using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidbody;
    [Space]
    [SerializeField] private float maxWalkingSpeed;
    [SerializeField] private float maxRunningSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;

    public bool IsSprinting { get; set; }

    private Vector2 _movementDirection;
    private Vector2 _movementVelocity;

    private void FixedUpdate()
    {
        if (_movementDirection != Vector2.zero)
        {
            Vector2 targetVelocity;

            if (IsSprinting)
            {
                targetVelocity = _movementDirection * maxRunningSpeed;
            }
            else
            {
                targetVelocity = _movementDirection * maxWalkingSpeed;
            }

            _movementVelocity = Vector2.Lerp(_movementVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);
            playerRigidbody.velocity = _movementVelocity;
        }
        else
        {
            _movementVelocity = Vector2.Lerp(_movementVelocity, Vector2.zero, deceleration * Time.fixedDeltaTime);
            playerRigidbody.velocity = _movementVelocity;
        }
    }

    public void SetMovementDirection(Vector2 movementDirection)
    {
        _movementDirection = movementDirection;
    }
}
