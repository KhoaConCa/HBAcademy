using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.SubState
{
    public class PlayerRunState : BaseState<PlayerController, PlayerStateFactory>
    {
        public PlayerRunState(PlayerController ctrl, PlayerStateFactory fac, ScriptableObject data) : base(ctrl, fac, data)
        {
            EnterState();
        }

        public override void EnterState()
        {
            Debug.Log("Run");
            Ctrl.anim.SetBool("isMove", true);
            Ctrl.anim.SetTrigger("Run");
        }

        public override void ExitState()
        {
            if (CurrentSubState != null)
                CurrentSubState.ExitState();

            Ctrl.anim.ResetTrigger("Run");
        }

        protected override void CheckSwitchState()
        {
            if (!Ctrl.XInput)
            {
                Ctrl.anim.SetBool("isMove", false);
                SwitchState(Fac.IdleState());
            }
        }

        protected override void UpdateState()
        {
            Ctrl.rg2D.velocity = new Vector2(Ctrl.playerData.moveSpeed * Ctrl.MoveDirection * Time.fixedDeltaTime, Ctrl.rg2D.velocity.y);

            if (Ctrl.MoveDirection != 0)
                Ctrl.transform.rotation = Quaternion.Euler(new Vector3(0, Ctrl.MoveDirection >= 0 ? 0 : 180, 0));
        }
    }
}