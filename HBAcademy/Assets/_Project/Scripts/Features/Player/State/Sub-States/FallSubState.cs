using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Features;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.State
{
    public class FallSubState : BaseState<PlayerController, StateFactory>
    {
        public FallSubState(PlayerController ctrl, StateFactory stateFac) : base(ctrl, stateFac)
        {
            InitializeSubState();
            EnterState();
        }

        protected override void InitializeSubState()
        {
            if (!Ctrl.IsMove)
                SetSubState(Fac.IdleSubState());
            else
                SetSubState(Fac.RunSubState());

        }
        public override void EnterState()
        {
            CurrentSubState?.EnterState();
        }
        protected override void UpdateState()
        {
            Ctrl.anim.SetFloat("velY", Ctrl.rg2D.velocity.y);
        }

        public override void ExitState()
        {
            Ctrl.anim.SetFloat("velY", 0);
            if (CurrentSubState != null)
                CurrentSubState.ExitState();
        }

        protected override void CheckSwitchState()
        {
            if (Ctrl.IsDoubleJump && Ctrl.JumpTriggered)
                SwitchState(Fac.JumpSuperState());
        }
    }
}
