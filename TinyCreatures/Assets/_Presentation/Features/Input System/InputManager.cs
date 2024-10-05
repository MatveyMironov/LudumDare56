using System;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [Space]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerAim playerLook;
    [SerializeField] private PlayerWeaponHandler playerWeaponHandler;

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
        if (isTriggerPulled)
        {
            playerWeaponHandler.PullTheTrigger();
        }
        else
        {
            playerWeaponHandler.ReleaseTheTrigger();
        }
    }

    internal void InvokeReload()
    {
        playerWeaponHandler.Reload();
    }
}
