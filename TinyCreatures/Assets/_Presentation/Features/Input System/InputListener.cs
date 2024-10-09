using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;

        private PlayerControls _playerControls;

        private void Awake()
        {
            _playerControls = new();

            _playerControls.MainActionMap.Move.started += OnMoveInput;
            _playerControls.MainActionMap.Move.performed += OnMoveInput;
            _playerControls.MainActionMap.Move.canceled += OnMoveInput;

            _playerControls.MainActionMap.Sprint.started += OnSprintInput;
            _playerControls.MainActionMap.Sprint.canceled += OnSprintInput;

            _playerControls.MainActionMap.Direct.performed += OnDirectInput;

            _playerControls.MainActionMap.Aim.started += OnAimInput;
            _playerControls.MainActionMap.Aim.canceled += OnAimInput;

            _playerControls.MainActionMap.Shoot.started += OnShootInput;
            _playerControls.MainActionMap.Shoot.canceled += OnShootInput;

            _playerControls.MainActionMap.Reload.performed += OnReloadInput;

            _playerControls.MainActionMap.Interact.performed += OnInteractInput;

            _playerControls.MainActionMap.Pause.performed += OnPauseInput;
        }

        private void OnMoveInput(InputAction.CallbackContext context)
        {
            Vector2 movementInput = context.ReadValue<Vector2>();
            inputManager.InvokeMovement(movementInput);
        }

        private void OnSprintInput(InputAction.CallbackContext context)
        {
            bool shouldSprint = context.ReadValueAsButton();
            inputManager.ToggleSprint(shouldSprint);
        }

        private void OnDirectInput(InputAction.CallbackContext context)
        {
            Vector2 mousePosition = context.ReadValue<Vector2>();
            inputManager.InvokeLook(mousePosition);
        }

        private void OnAimInput(InputAction.CallbackContext context)
        {

        }

        private void OnShootInput(InputAction.CallbackContext context)
        {
            bool isTriggerPulled = context.ReadValueAsButton();
            inputManager.HandleShooting(isTriggerPulled);
        }

        private void OnReloadInput(InputAction.CallbackContext context)
        {
            inputManager.InvokeReload();
        }

        private void OnInteractInput(InputAction.CallbackContext context)
        {
            inputManager.InvokeInteraction();
        }

        private void OnPauseInput(InputAction.CallbackContext context)
        {
            inputManager.TogglePause();
        }

        private void OnEnable()
        {
            _playerControls.MainActionMap.Enable();
        }

        private void OnDisable()
        {
            _playerControls.MainActionMap.Disable();
        }
    }
}
