using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Vox.Features
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public void OnMoveInput(InputAction.CallbackContext context)
        {
            RawMovementInput = context.ReadValue<Vector2>();

            NormalizedInputX = Mathf.RoundToInt(RawMovementInput.x);
            NormalizedInputY = Mathf.RoundToInt(RawMovementInput.y);

            //Debug.Log($"Normalized Input X: {NormalizedInputX}, Y: {NormalizedInputY}");
            //Debug.Log($"Move Input: {RawMovementInput}");
        }

        public void OnJumpInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                JumpInput = true;
                JumpInputStop = false;
                _jumpInputStartTime = Time.time;
                //Debug.Log("Jump pushed down now");
            }

            if (context.canceled)
            {
                JumpInputStop = true;
                //Debug.Log("Jump released now");
            }

            //Debug.Log("Jump");
        }

        public void OnAttackInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                AttackInput = true;
                //Debug.Log("Attack pushed down now");
            }
            if (context.canceled)
            {
                AttackInput = false;
                //Debug.Log("Attack released now");
            }
            //Debug.Log("Attack");
        }

        public void OnThrowInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                ThrowInput = true;
                //Debug.Log("Throw pushed down now");
            }
            if (context.canceled)
            {
                ThrowInput = false;
                //Debug.Log("Throw released now");
            }
            //Debug.Log("Throw");
        }

        public void UseJumpInput() => JumpInput = false;

        public void CheckJumpInputHoldTime()
        {
            if (Time.time >= _jumpInputStartTime + _inputHoldTime)
                JumpInput = false;
        }

        public Vector2 RawMovementInput { get; private set; }
        public int NormalizedInputX { get; private set; }
        public int NormalizedInputY { get; private set; }
        public bool JumpInput { get; private set; }
        public bool JumpInputStop { get; private set; }
        public bool AttackInput { get; private set; }
        public bool ThrowInput { get; private set; }

        [SerializeField] private float _inputHoldTime = 0.2f;
        [SerializeField] private PlayerInput _playerInput;

        private float _jumpInputStartTime;
    }
}
