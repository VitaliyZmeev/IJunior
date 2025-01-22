using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer2d
{
    public class PlayerInput : MonoBehaviour
    {
        private InputActions _inputActions;
        private bool _isJump;

        private void Awake()
        {
            _inputActions = new InputActions();
        }

        private void OnEnable()
        {
            _inputActions.Enable();
            _inputActions.Player.Jump.performed += OnJumpPerformed;
        }

        private void OnDisable()
        {
            _inputActions.Disable();
            _inputActions.Player.Jump.performed -= OnJumpPerformed;
        }

        public float GetMoveDirection() => _inputActions.Player.Move.ReadValue<float>();

        public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);

        private bool GetBoolAsTrigger(ref bool value)
        {
            bool localValue = value;
            value = false;

            return localValue;
        }

        private void OnJumpPerformed(InputAction.CallbackContext context) => _isJump = true;
    }
}