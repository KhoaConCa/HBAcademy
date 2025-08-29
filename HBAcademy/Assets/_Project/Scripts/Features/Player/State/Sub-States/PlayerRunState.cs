using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Featrures.SuperState;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.SubState
{
    public class PlayerRunState : BaseState<PlayerController, PlayerStateFactory>
    {
        public PlayerRunState(PlayerController ctrl, PlayerStateFactory fac, ScriptableObject data) : base(ctrl, fac, data)
        {
            //EnterState();
        }

        public override void EnterState()
        {
            base.EnterState();

            Debug.Log("Run");
            Ctrl.anim.SetBool("isMove", true);
            Ctrl.anim.SetTrigger("Run");
        }

        public override void ExitState()
        {
            base.ExitState();

            if (CurrentSubState != null)
                CurrentSubState.ExitState();

            Ctrl.anim.SetBool("isMove", false);
            Ctrl.anim.ResetTrigger("Run");
        }

        protected override void CheckSwitchState()
        {
            if (Ctrl.inputHandler.NormalizedInputX == 0)
            {
                //Ctrl.anim.SetBool("isMove", false);
                SwitchState(Fac.IdleState());
            }
            else if (Ctrl.inputHandler.JumpInput)
            {
                //Ctrl.anim.SetBool("isMove", false);
                SwitchState(Fac.JumpState());
            }
        }

        protected override void UpdateState()
        {
            Ctrl.rg2D.velocity = new Vector2(Ctrl.playerData.moveSpeed * Ctrl.inputHandler.NormalizedInputX * Time.fixedDeltaTime, Ctrl.rg2D.velocity.y);

            if (Ctrl.inputHandler.NormalizedInputX != 0)
                Ctrl.transform.rotation = Quaternion.Euler(new Vector3(0, Ctrl.inputHandler.NormalizedInputX >= 0 ? 0 : 180, 0));
        }
    }
}