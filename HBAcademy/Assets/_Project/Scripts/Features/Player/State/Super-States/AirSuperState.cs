using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.State
{
    //public class AirSuperState : BaseState<PlayerController, StateFactory>
    //{
    //    public AirSuperState(PlayerController ctrl, StateFactory stateFac) : base(ctrl, stateFac)
    //    {
    //        IsRootState = true;

    //        InitializeSubState();
    //        EnterState();
    //    }

    //    protected override void InitializeSubState()
    //    {
    //        if (Ctrl.IsJump)
    //            SetSubState(Fac.JumpSuperState());
    //        else if (Ctrl.rg2D.velocity.y <= 0)
    //            SetSubState(Fac.FallSubState());
    //    }

    //    public override void EnterState()
    //    {
    //        CurrentSubState?.EnterState();
    //    }

    //    protected override void UpdateState()
    //    {
    //    }

    //    public override void ExitState()
    //    {

    //        if (CurrentSubState != null)
    //            CurrentSubState.ExitState();
    //    }

    //    protected override void CheckSwitchState()
    //    {
    //        if (Ctrl.IsGrounded)
    //            SwitchState(Fac.GroundSuperState());
    //    }
    //}
}
