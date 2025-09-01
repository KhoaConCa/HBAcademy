using UnityEngine;
using Vox.Features.Player;
using Vox.Features.Player.Data;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.SubState
{
    /// <summary>
    /// PlayerAirState - Super-state.<br/>
    /// Developer: Duong Nhat Khoa - created on: 31/08/2025.
    /// </summary>
    public class PlayerAirState : BaseState<PlayerController, PlayerStateFactory>
    {
        #region --- Constructor ---

        public PlayerAirState(PlayerController ctrl, PlayerStateFactory stateFac, PlayerData data, string animBool) 
            : base(ctrl, stateFac, data, animBool) { }

        #endregion

        #region --- Methods ---

        public override void EnterState()
        {
            Debug.Log("Air");
        }

        public override void ExitState()
        {

        }

        protected override void CheckConditions()
        {
            _isGrounded = Ctrl.col2D.Cast(Vector2.down, Ctrl.contactFilter2D, new RaycastHit2D[5], 0.05f) > 0;
        }

        protected override void CheckSwitchState()
        {
            if (!_isGrounded && _isFalling)
            {
                SwitchState(Fac.FallState());
            }
        }

        protected override void UpdateState()
        {
            CheckCoyoteTime();

            _xInput = Ctrl.inputHandler.NormalizedInputX;
            _jumpInput = Ctrl.inputHandler.JumpInput;
            _jumpInputStop = Ctrl.inputHandler.JumpInputStop;

            Ctrl.anim.SetFloat("yVelocity", Ctrl.rg2D.velocity.y);

            Ctrl.rg2D.velocity = new Vector2(Ctrl.playerData.moveSpeed * _xInput * Time.fixedDeltaTime
                                            , Ctrl.rg2D.velocity.y);
            Ctrl.transform.rotation = Quaternion.Euler(new Vector3(0, _xInput >= 0 ? 0 : 180, 0));

            if (Ctrl.rg2D.velocity.y < 0.01f)
                _isFalling = true;
        }

        /// <summary>
        /// Allow player can still jump for a short time after leaving the ground.
        /// </summary>
        private void CheckCoyoteTime()
        {
            if (_coyoteTime && Time.time > startTime + Ctrl.playerData.coyoteTime)
            {
                _coyoteTime = false;
            }
        }

        public void StartCoyoteTime() => _coyoteTime = true;

        public void SetIsJumping() => _isJumping = true;

        public void ResetIsFalling() => _isFalling = false;

        #endregion

        #region --- Fields ---

        private int _xInput;
        private bool _jumpInput;
        private bool _jumpInputStop;

        private bool _coyoteTime;

        private bool _isGrounded;
        private bool _isJumping;
        private bool _isFalling;

        #endregion
    }
}