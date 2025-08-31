using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Vox.Featrures.SuperState;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.SubState
{
    public class PlayerIdleState : PlayerGroundedState //BaseState<PlayerController, PlayerStateFactory>
    {
        public PlayerIdleState(PlayerController ctrl, PlayerStateFactory stateFac, PlayerData data, string animTrigger) 
            : base(ctrl, stateFac, data, animTrigger) { }

        public override void EnterState()
        {
            base.EnterState();

            Debug.Log("Idle");
            //Ctrl.anim.SetTrigger("Idle");
            float moveSpeed = Mathf.Clamp(Mathf.Abs(Ctrl.rg2D.velocity.x), 0, 2);

            if (moveSpeed > 0.01f)
            {
                Ctrl.rg2D.velocity = new Vector2(moveSpeed - _acceleration, Ctrl.rg2D.velocity.y);
            }

            //Ctrl.anim.SetBool("isMove", false);
        }

        public override void ExitState()
        {
            base.ExitState();

            //if (CurrentSubState != null)
            //    CurrentSubState.ExitState();

            //Ctrl.anim.ResetTrigger("Idle");
        }

        protected override void CheckSwitchState()
        {
            //if (Ctrl.inputHandler.NormalizedInputX != 0)
            //    SwitchState(Fac.RunState());
            //else if (Ctrl.inputHandler.JumpInput)
            //    SwitchState(Fac.JumpState());
            base.CheckSwitchState();

            if (!isExitingState && _xInput != 0)
            {
                SwitchState(Fac.RunState());
            }
        }

        protected override void UpdateState()
        {
            base.UpdateState();
            //float moveSpeed = Mathf.Clamp(Mathf.Abs(Ctrl.rg2D.velocity.x), 0, 2);

            //if (moveSpeed > 0.01f)
            //{
            //    Ctrl.rg2D.velocity = new Vector2(moveSpeed - _acceleration, Ctrl.rg2D.velocity.y);
            //}
        }

        [SerializeField] private float _acceleration = 0.4f;
    }
}