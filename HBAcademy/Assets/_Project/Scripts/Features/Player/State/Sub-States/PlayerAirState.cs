using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Windows;
using Vox.Featrures.SuperState;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.SubState
{
    public class PlayerAirState : BaseState<PlayerController, PlayerStateFactory>
    {
        public PlayerAirState(PlayerController ctrl, PlayerStateFactory stateFac, PlayerData data, string animBool) 
            : base(ctrl, stateFac, data, animBool)
        {

        }

        public override void EnterState()
        {
            Debug.Log("Air");
        }

        public override void ExitState()
        {
            //_isFalling = false;
        }

        protected override void CheckConditions()
        {
            _isGrounded = Ctrl.col2D.Cast(Vector2.down, Ctrl.contactFilter2D, new RaycastHit2D[5], 0.05f) > 0;
        }

        protected override void CheckSwitchState()
        {
            if (!_isGrounded)
            {
                if (_isFalling)
                    SwitchState(Fac.FallState());
            }

            //if (!_isGrounded && Ctrl.rg2D.velocity.y < 0.01f)
            //{
            //    //Debug.Log("Land");
            //    SwitchState(Fac.FallState());
            //}
            //else
            //{
            //    Ctrl.rg2D.velocity = new Vector2(Ctrl.playerData.moveSpeed * _xInput * Time.fixedDeltaTime
            //                                , Ctrl.rg2D.velocity.y);
            //    Ctrl.transform.rotation = Quaternion.Euler(new Vector3(0, _xInput >= 0 ? 0 : 180, 0));
            //}
            //if (_isGrounded && Ctrl.rg2D.velocity.y < 0.01f)
            //{
            //    SwitchState(Fac.FallState());
            //}
            ////else if (jumpInput && player.JumpState.CanJump())
            ////{
            ////    stateMachine.ChangeState(player.JumpState);
            ////}
            //else
            //{
            //    core.Movement.CheckIfShouldFlip(xInput);
            //    core.Movement.SetVelocityX(playerData.movementVelocity * xInput);

            //    player.Anim.SetFloat("yVelocity", core.Movement.CurrentVelocity.y);
            //    player.Anim.SetFloat("xVelocity", Mathf.Abs(core.Movement.CurrentVelocity.x));
            //}
        }

        protected override void UpdateState()
        {
            CheckCoyoteTime();

            _xInput = Ctrl.inputHandler.NormalizedInputX;
            _jumpInput = Ctrl.inputHandler.JumpInput;
            _jumpInputStop = Ctrl.inputHandler.JumpInputStop;

            Ctrl.anim.SetFloat("yVelocity", Ctrl.rg2D.velocity.y);
            //Ctrl.anim.SetFloat("xVelocity", Mathf.Abs(Ctrl.rg2D.velocity.x));

            Ctrl.rg2D.velocity = new Vector2(Ctrl.playerData.moveSpeed * _xInput * Time.fixedDeltaTime
                                            , Ctrl.rg2D.velocity.y);
            Ctrl.transform.rotation = Quaternion.Euler(new Vector3(0, _xInput >= 0 ? 0 : 180, 0));

            if (Ctrl.rg2D.velocity.y < 0.01f)
                _isFalling = true;
            //_xInput = Ctrl.inputHandler.NormalizedInputX;
            //_jumpInput = Ctrl.inputHandler.JumpInput;
            //_jumpInputStop = Ctrl.inputHandler.JumpInputStop;

            //CheckJumpMultiplier();
        }

        //private void CheckJumpMultiplier()
        //{
        //    if (_isJumping)
        //    {
        //        if (_jumpInputStop)
        //        {
        //            core.Movement.SetVelocityY(core.Movement.CurrentVelocity.y * playerData.variableJumpHeightMultiplier);
        //            _isJumping = false;
        //        }
        //        else if (core.Movement.CurrentVelocity.y <= 0f)
        //        {
        //            _isJumping = false;
        //        }

        //    }
        //}

        private void CheckCoyoteTime()
        {
            if (_coyoteTime && Time.time > startTime + Ctrl.playerData.coyoteTime)
            {
                _coyoteTime = false;
                Fac.JumpState().DecreaseAmountOfJumpsLeft();
            }
        }

        public void StartCoyoteTime() => _coyoteTime = true;
        public void SetIsJumping() => _isJumping = true;
        public void ResetIsFalling() => _isFalling = false;

        private int _xInput;
        private bool _jumpInput;
        private bool _jumpInputStop;

        private bool _coyoteTime;

        private bool _isGrounded;
        private bool _isJumping;
        private bool _isFalling;
    }
}