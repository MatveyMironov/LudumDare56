using Pause;
using UnityEngine;
using UnityEngine.EventSystems;
using Player;
using WeaponSystem;

namespace Input
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private EventSystem eventSystem;
        [Space]
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerAim playerLook;
        [SerializeField] private WeaponEquiper weaponEquiper;
        [SerializeField] private PlayerWeaponHandler playerWeaponHandler;
        [SerializeField] private InteractionController interactionController;
        [SerializeField] private PauseManager pauseManager;

        public bool InputDisabled { get; set; }

        public void InvokeMovement(Vector2 movementInput)
        {
            if (InputDisabled) { return; }

            playerMovement.SetMovementDirection(movementInput);
        }

        public void ToggleSprint(bool shouldSprint)
        {
            if (InputDisabled) { return; }

            //playerMovement.IsSprinting = shouldSprint;
        }

        public void InvokeLook(Vector2 mousePosition)
        {
            if (InputDisabled) { return; }

            Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            playerLook.SetAim(mouseWorldPosition);
        }

        public void HandleShooting(bool isTriggerPulled)
        {
            if (InputDisabled) { return; }

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
            if (InputDisabled) { return; }

            playerWeaponHandler.StartReloadingWeapon();
        }

        public void InvokeInteraction()
        {
            if (InputDisabled) { return; }

            interactionController.Interact();
        }

        public void InvokeScroll(float scroll)
        {
            if (scroll < 0)
            {
                weaponEquiper.StartEquipingPreviousWeapon();
            }
            else if (scroll > 0)
            {
                weaponEquiper.StartEquipingNextWeapon();
            }
        }

        public void TogglePause()
        {
            if (InputDisabled) { return; }

            if (pauseManager.IsPaused)
            {
                pauseManager.ResumeGame();
            }
            else
            {
                pauseManager.PauseGame();
            }
        }
    }
}
