using UnityEngine;
using Vox.Features.Player;
using Vox.Features.Player.Data;
using Vox.Ultilities.StateMachine;

namespace Vox.Featrures.SuperState
{
    /// <summary>
    /// PlayerGroundedState - Super-state.<br/>
    /// Developer: Duong Nhat Khoa - created on: 31/08/2025.
    /// </summary>
    public class PlayerGroundedState : BaseState<PlayerController, PlayerStateFactory>
    {
        #region --- Constructor ---

        public PlayerGroundedState(PlayerController ctrl, PlayerStateFactory stateFac, PlayerData data, string animTrigger) 
            : base(ctrl, stateFac, data, animTrigger) { }

        #endregion

        #region --- Methods ---

        public override void EnterState()
        {
            base.EnterState();

            CheckConditions();

            Ctrl.anim.SetBool("isGrounded", _isGrounded);

            Debug.Log("Grounded");
        }

        protected override void UpdateState()
        {
            _xInput = Ctrl.inputHandler.NormalizedInputX;
            _yInput = Ctrl.inputHandler.NormalizedInputY;
            _jumpInput = Ctrl.inputHandler.JumpInput;
        }

        public override void ExitState()
        {
            base.ExitState();

            Ctrl.anim.SetBool("isGrounded", _isGrounded);

            _jumpInput = false;
        }

        protected override void CheckSwitchState()
        {
            if (!_isGrounded)
            {
                Fac.AirState().StartCoyoteTime();
                SwitchState(Fac.AirState());
            }
            else if (_jumpInput)
            {
                SwitchState(Fac.JumpState());
            }
            else if (Ctrl.inputHandler.AttackInput)
            {
                SwitchState(Fac.AttackState());
            }
            else if (Ctrl.inputHandler.ThrowInput)
            {
                SwitchState(Fac.ThrowState());
            }
        }

        protected override void CheckConditions()
        {
             _isGrounded = Ctrl.col2D.Cast(Vector2.down, Ctrl.contactFilter2D, new RaycastHit2D[5], 0.05f) > 0;
        }

        #endregion

        #region --- Fields ---

        protected int _xInput;
        protected int _yInput;
        protected bool _jumpInput;

        protected bool _isGrounded;

        #endregion
    }
}