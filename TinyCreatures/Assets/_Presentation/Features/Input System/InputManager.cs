using Pause;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private EventSystem eventSystem;
    [Space]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerAim playerLook;
    [SerializeField] private PlayerWeaponHandler playerWeaponHandler;
    [SerializeField] private InteractionController interactionController;
    [SerializeField] private PauseManager pauseManager;

    public void InvokeMovement(Vector2 movementInput)
    {
        playerMovement.SetMovementDirection(movementInput);
    }

    public void ToggleSprint(bool shouldSprint)
    {
        playerMovement.IsSprinting = shouldSprint;
    }

    public void InvokeLook(Vector2 mousePosition)
    {
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        playerLook.SetAim(mouseWorldPosition);
    }

    public void HandleShooting(bool isTriggerPulled)
    {
        if (CheckIfPointerOverUI()) { return; }

        if (isTriggerPulled)
        {
            playerWeaponHandler.PullWeaponTrigger();
        }
        else
        {
            playerWeaponHandler.ReleaseWeaponTrigger();
        }
    }

    internal void InvokeReload()
    {
        playerWeaponHandler.ReloadWeapon();
    }

    public void InvokeInteraction()
    {
        interactionController.Interact();
    }

    public void TogglePause()
    {
        if (pauseManager.IsPaused)
        {
            pauseManager.ResumeGame();
        }
        else
        {
            pauseManager.PauseGame();
        }
    }

    private bool CheckIfPointerOverUI()
    {
        return eventSystem.IsPointerOverGameObject();
    }
}
