using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.State
{
    public class GroundSuperState : BaseState<PlayerController, StateFactory>
    {
        public GroundSuperState(PlayerController ctrl, StateFactory stateFac) : base(ctrl, stateFac)
        {
            IsRootState = true;

            InitializeSubState();
            EnterState();
        }

        protected override void InitializeSubState()
        {
            SetSubState(Fac.IdleSubState());

        }
        public override void EnterState()
        {
            CurrentSubState.EnterState();
        }

        protected override void UpdateState()
        {
            Ctrl.anim.SetBool("isGround", Ctrl.IsGrounded);
        }

        public override void ExitState()
        {
            Ctrl.anim.SetBool("isGround", false);
            if (CurrentSubState != null)
                CurrentSubState.ExitState();
        }

        protected override void CheckSwitchState()
        {
            if (Ctrl.JumpTriggered || !Ctrl.IsGrounded)
                SwitchState(Fac.AirSuperState());
        }

    }
}
