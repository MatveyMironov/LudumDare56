using Pause;
using UnityEngine;
using UnityEngine.EventSystems;
using Player;
using InventorySystem;

namespace Input
{
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
        [SerializeField] private InventoryMenu inventoryMenu;

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
            if (InputDisabled) { return; }

            playerWeaponHandler.StartReloadingWeapon();
        }

        public void InvokeInteraction()
        {
            if (InputDisabled) { return; }

            interactionController.Interact();
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

        public void ToggleInventoryMenu()
        {
            if (InputDisabled) { return; }

            if (inventoryMenu.IsOpened)
            {
                inventoryMenu.CloseMenu();
            }
            else
            {
                inventoryMenu.OpenMenu();
            }
        }

        private bool CheckIfPointerOverUI()
        {
            return eventSystem.IsPointerOverGameObject();
        }
    }
}
