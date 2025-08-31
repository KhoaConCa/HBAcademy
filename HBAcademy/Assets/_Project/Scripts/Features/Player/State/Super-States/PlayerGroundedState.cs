using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Features;
using Vox.Ultilities.StateMachine;

namespace Vox.Featrures.SuperState
{
    public class PlayerGroundedState : BaseState<PlayerController, PlayerStateFactory>
    {
        public PlayerGroundedState(PlayerController ctrl, PlayerStateFactory stateFac, PlayerData data, string animTrigger) 
            : base(ctrl, stateFac, data, animTrigger) { }

        //protected override void InitializeSubState()
        //{
        //    SetSubState(Fac.IdleState());
        //}
         
        public override void EnterState()
        {
            //SetSuperState(this);

            base.EnterState();

            CheckConditions();

            Fac.JumpState().ResetAmountOfJumpsLeft();
            Ctrl.anim.SetBool("isGrounded", _isGrounded);

            Debug.Log("Grounded");
            //CurrentSubState.EnterState();
            //base.EnterState();
            //if (CurrentSubState == null)
            //    SetSubState(Fac.IdleState());
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

            //if (CurrentSubState != null)
            //    CurrentSubState.ExitState();

            _jumpInput = false;
        }

        protected override void CheckSwitchState()
        {
            if (!_isGrounded)
            {
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
            //Debug.Log("IsGrounded: " + _isGrounded);
        }

        #region --- Fields ---

        protected int _xInput;
        protected int _yInput;
        protected bool _jumpInput;

        protected bool _isGrounded;

        #endregion
    }
}