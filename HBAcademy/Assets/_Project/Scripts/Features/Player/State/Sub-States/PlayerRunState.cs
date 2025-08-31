using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Featrures.SuperState;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.SubState
{
    public class PlayerRunState : PlayerGroundedState //BaseState<PlayerController, PlayerStateFactory>
    {
        public PlayerRunState(PlayerController ctrl, PlayerStateFactory fac, PlayerData data, string animTrigger) 
            : base(ctrl, fac, data, animTrigger) { }

        public override void EnterState()
        {
            base.EnterState();

            Debug.Log("Run");
            //Ctrl.anim.SetBool("isMove", true);
            //Ctrl.anim.SetTrigger("Run");
        }

        public override void ExitState()
        {
            base.ExitState();

            //if (CurrentSubState != null)
            //    CurrentSubState.ExitState();

            //Ctrl.anim.SetBool("isMove", false);
            //Ctrl.anim.ResetTrigger("Run");
        }

        protected override void CheckSwitchState()
        {
            base.CheckSwitchState();

            if (!isExitingState && _xInput == 0)
            {
                SwitchState(Fac.IdleState());

                //Ctrl.anim.SetBool("isMove", false);
            }
            else if (!_isGrounded && _xInput != 0)
            {
                //Ctrl.anim.SetBool("isMove", false);
                SwitchState(Fac.FallState());
            }
            //else if (Ctrl.inputHandler.JumpInput)
            //{
            //    //Ctrl.anim.SetBool("isMove", false);
            //    //SwitchState(Fac.JumpState());
            //}
        }

        protected override void UpdateState()
        {
            base.UpdateState();
            MovementLogic();
        }

        public void MovementLogic()
        {
            Ctrl.rg2D.velocity = new Vector2(Ctrl.playerData.moveSpeed * _xInput * Time.fixedDeltaTime
                                                        , Ctrl.rg2D.velocity.y);

            if (_xInput != 0)
                Ctrl.transform.rotation = Quaternion.Euler(new Vector3(0, _xInput >= 0 ? 0 : 180, 0));
        }
    }
}