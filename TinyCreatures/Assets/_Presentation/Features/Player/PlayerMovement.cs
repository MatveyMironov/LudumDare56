using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidbody;
    [Space]
    [SerializeField] private float maxWalkingSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    [Space]
    [SerializeField] private Animator animator;

    private Vector2 _movementDirection;
    private Vector2 _movementVelocity;

    private void Update()
    {
        if (_movementDirection != Vector2.zero)
        {
            Vector2 targetVelocity;
            targetVelocity = _movementDirection * maxWalkingSpeed;
            _movementVelocity = Vector2.Lerp(_movementVelocity, targetVelocity, acceleration * Time.deltaTime);
            playerRigidbody.velocity = _movementVelocity;
            animator.SetBool("IsWalking", true);
        }
        else
        {
            _movementVelocity = Vector2.Lerp(_movementVelocity, Vector2.zero, deceleration * Time.deltaTime);
            playerRigidbody.velocity = _movementVelocity;
            animator.SetBool("IsWalking", false);
        }
    }

    public void SetMovementDirection(Vector2 movementDirection)
    {
        _movementDirection = movementDirection;
    }
}
