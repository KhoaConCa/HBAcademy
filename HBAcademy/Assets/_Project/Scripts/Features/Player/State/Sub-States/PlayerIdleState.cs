using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Vox.Featrures.SuperState;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.SubState
{
    public class PlayerIdleState : BaseState<PlayerController, PlayerStateFactory>
    {
        public PlayerIdleState(PlayerController ctrl, PlayerStateFactory stateFac, PlayerData data) : base(ctrl, stateFac, data)
        {
            EnterState();
        }

        public override void EnterState()
        {
            Debug.Log("Idle");
            Ctrl.anim.SetTrigger("Idle");
            Ctrl.anim.SetBool("isMove", false);
        }

        public override void ExitState()
        {
            if (CurrentSubState != null)
                CurrentSubState.ExitState();

            Ctrl.anim.ResetTrigger("Idle");
        }

        protected override void CheckSwitchState()
        {
            if (Ctrl.XInput)
                SwitchState(Fac.RunState());
        }

        protected override void UpdateState()
        {
            float moveSpeed = Mathf.Clamp(Mathf.Abs(Ctrl.rg2D.velocity.x), 0, 2);

            if (moveSpeed > 0.01f)
            {
                Ctrl.rg2D.velocity = new Vector2(moveSpeed - _acceleration, Ctrl.rg2D.velocity.y);
            }
        }

        private float _acceleration = 0.4f;
    }
}