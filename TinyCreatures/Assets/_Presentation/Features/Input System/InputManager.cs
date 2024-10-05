using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    public void InvokeMovement(Vector2 movementInput)
    {
        playerMovement.SetMovementDirection(movementInput);
    }

    public void ToggleSprint(bool shouldSprint)
    {
        playerMovement.IsSprinting = shouldSprint;
    }
}
