using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Featrures.SuperState;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.SubState
{
    public class PlayerFallState : PlayerGroundedState // BaseState<PlayerController, PlayerStateFactory>
    {
        public PlayerFallState(PlayerController ctrl, PlayerStateFactory fac, PlayerData data, string animTrigger) : base(ctrl, fac, data, animTrigger)
        {
        }

        public override void EnterState()
        {
            base.EnterState();
            Debug.Log("Fall");
            //base.EnterState();
            Ctrl.anim.SetBool("isFall", true);
            Fac.AirState().ResetIsFalling();

            //Ctrl.rg2D.velocity = new Vector2(Ctrl.rg2D.velocity.x, Ctrl.rg2D.velocity.y);
        }

        public override void ExitState()
        {
            Ctrl.anim.SetBool("isFall", false);
        }

        protected override void CheckSwitchState()
        {
            if (!isExitingState)
            {
                if (!_isGrounded && _xInput != 0)
                {
                    Ctrl.rg2D.velocity = new Vector2(_xInput, Ctrl.rg2D.velocity.y);
                }
                else if (isAnimationFinished)
                {
                    SwitchState(Fac.IdleState());
                }
                else if (_isGrounded && Ctrl.inputHandler.NormalizedInputX != 0)
                    SwitchState(Fac.RunState());
            }
        }

        protected override void UpdateState()
        {
            Ctrl.anim.SetFloat("yVelocity", Ctrl.rg2D.velocity.y);
            Ctrl.rg2D.velocity = new Vector2(Ctrl.playerData.moveSpeed * Ctrl.inputHandler.NormalizedInputX * Time.fixedDeltaTime
                    , Ctrl.rg2D.velocity.y);

            if (Ctrl.inputHandler.NormalizedInputX != 0)
                Ctrl.transform.rotation = Quaternion.Euler(new Vector3(0, Ctrl.inputHandler.NormalizedInputX >= 0 ? 0 : 180, 0));

            if (_isGrounded)
                isAnimationFinished = true;
        }
    }
}