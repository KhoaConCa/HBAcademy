using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Vox.Features.Player
{
    /// <summary>
    /// PlayerInputHandler - Handles player input using the new Input System.<br/>
    /// Developer: Duong Nhat Khoa - created on: 31/08/2025.
    /// </summary>
    public class PlayerInputHandler : MonoBehaviour
    {
        #region --- Unity Methods ---

        private void Update()
        {
            CheckJumpInputHoldTime();
        }

        #endregion
        #region --- Methods ---

        public void OnMoveInput(InputAction.CallbackContext context)
        {
            RawMovementInput = context.ReadValue<Vector2>();

            NormalizedInputX = Mathf.RoundToInt(RawMovementInput.x);
            NormalizedInputY = Mathf.RoundToInt(RawMovementInput.y);
        }

        public void OnJumpInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                JumpInput = true;
                JumpInputStop = false;
                _jumpInputStartTime = Time.time;
            }

            if (context.canceled)
            {
                JumpInputStop = true;
            }
        }

        public void OnAttackInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                AttackInput = true;
            }
            if (context.canceled)
            {
                AttackInput = false;
            }
        }

        public void OnThrowInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                ThrowInput = true;
            }
            if (context.canceled)
            {
                ThrowInput = false;
            }
        }

        public void UseJumpInput() => JumpInput = false;

        public void CheckJumpInputHoldTime()
        {
            if (Time.time >= _jumpInputStartTime + _inputHoldTime)
                JumpInput = false;
        }

        #endregion

        #region --- Properties ---

        public Vector2 RawMovementInput { get; private set; }
        public int NormalizedInputX { get; set; }
        public int NormalizedInputY { get; private set; }
        public bool JumpInput { get; private set; }
        public bool JumpInputStop { get; private set; }
        public bool AttackInput { get; private set; }
        public bool ThrowInput { get; private set; }

        #endregion

        #region --- Fields ---

        [SerializeField] private float _inputHoldTime = 0.2f;
        [SerializeField] private PlayerInput _playerInput;

        private float _jumpInputStartTime;

        #endregion
    }
}
