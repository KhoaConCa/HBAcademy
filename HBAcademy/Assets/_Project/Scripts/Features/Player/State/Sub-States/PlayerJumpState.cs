using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Vox.Features.SuperState;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.SubState
{
    public class PlayerJumpState : PlayerAbilityState //BaseState<PlayerController, PlayerStateFactory>
    {
        public PlayerJumpState(PlayerController ctrl, PlayerStateFactory fac, PlayerData data, string animTrigger) 
            : base(ctrl, fac, data, animTrigger) 
        {
            amountOfJumpsLeft = Ctrl.playerData.amountOfJumps;
        }

        public override void EnterState()
        {
            Debug.Log("Jump");

            base.EnterState();
            //Ctrl.anim.SetBool("inAir", true);
            Ctrl.inputHandler.UseJumpInput();
            _isAbilityDone = true;
            //Debug.Log(_isGrounded);
            amountOfJumpsLeft--;
            Fac.AirState().SetIsJumping();
            //Ctrl.anim.SetTrigger("Jump");
            Ctrl.rg2D.velocity = new Vector2(Ctrl.rg2D.velocity.x, Ctrl.playerData.jumpForce);
            
        }

        public override void ExitState()
        {
            base.ExitState();

            //throw new System.NotImplementedException();
        }

        protected override void CheckSwitchState()
        {
            //throw new System.NotImplementedException();
        }

        protected override void UpdateState()
        {
            Ctrl.rg2D.velocity = new Vector2(Ctrl.playerData.moveSpeed * Ctrl.inputHandler.NormalizedInputX * Time.fixedDeltaTime
                                , Ctrl.rg2D.velocity.y);

            if (Ctrl.inputHandler.NormalizedInputX != 0)
                Ctrl.transform.rotation = Quaternion.Euler(new Vector3(0, Ctrl.inputHandler.NormalizedInputX >= 0 ? 0 : 180, 0));

            if (Ctrl.rg2D.velocity.y < 0)
            {
                //Ctrl.anim.SetFloat("velY", Ctrl.rg2D.velocity.y);
                SwitchState(Fac.FallState());
            }

            //if (_isGrounded && Ctrl.inputHandler.NormalizedInputX != 0)
            //    SwitchState(Fac.RunState());
        }

        public bool CanJump()
        {
            if (amountOfJumpsLeft > 0)
                return true;
            else
                return false;
        }

        public void ResetAmountOfJumpsLeft() => amountOfJumpsLeft = Ctrl.playerData.amountOfJumps;

        public void DecreaseAmountOfJumpsLeft() => amountOfJumpsLeft--;

        private int amountOfJumpsLeft;
    }
}