using System;
using UnityEngine;
using UnityEngine.InputSystem;
using PlayerInput = InputActions.PlayerInput;

namespace PlayerControlSystem
{
    public class InputReader : MonoBehaviour
    {
        private PlayerInput _playerInput;

        public event Action Moving;

        private void OnEnable()
        {
            _playerInput = new PlayerInput();
            _playerInput.Enable();

            _playerInput.Player.Jump.performed += OnJumpPerformed;
        }

        private void OnDisable()
        {
            _playerInput.Player.Jump.performed -= OnJumpPerformed;
            _playerInput.Disable();
        }

        private void OnJumpPerformed(InputAction.CallbackContext _)
        {
            Moving?.Invoke();
        }
    }
}