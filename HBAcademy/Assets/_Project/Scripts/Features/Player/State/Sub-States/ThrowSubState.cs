using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.State
{
    //public class ThrowSubState : BaseState<PlayerController, StateFactory>
    //{
    //    public ThrowSubState(PlayerController ctrl, StateFactory stateFac) : base(ctrl, stateFac)
    //    {
    //        EnterState();
    //    }
    //    public override void EnterState()
    //    {
    //        Ctrl.anim.SetTrigger("Throw");
    //    }
    //    protected override void UpdateState()
    //    {

    //    }
    //    public override void ExitState()
    //    {
    //        if (CurrentSubState != null)
    //            CurrentSubState.ExitState();

    //        Ctrl.anim.ResetTrigger("Throw");
    //    }
    //    protected override void CheckSwitchState()
    //    {
    //        if (!Ctrl.IsThrow)
    //        {
    //            Ctrl.IsThrow = false;
    //            SwitchState(Fac.IdleSubState());
    //        }
    //    }
    //}
}
