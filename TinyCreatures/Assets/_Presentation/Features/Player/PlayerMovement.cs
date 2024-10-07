using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidbody;
    [Space]
    [SerializeField] private float maxWalkingSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;

    [Header("Effects")]
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip movingClip;

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

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            _movementVelocity = Vector2.Lerp(_movementVelocity, Vector2.zero, deceleration * Time.deltaTime);
            playerRigidbody.velocity = _movementVelocity;
            animator.SetBool("IsWalking", false);
            //audioSource.Stop();
        }
    }

    public void SetMovementDirection(Vector2 movementDirection)
    {
        _movementDirection = movementDirection;
    }
}
