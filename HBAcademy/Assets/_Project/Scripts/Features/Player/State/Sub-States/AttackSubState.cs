using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.State
{
    //public class AttackSubState : BaseState<PlayerController, StateFactory>
    //{
    //    public AttackSubState(PlayerController ctrl, StateFactory stateFac) : base(ctrl, stateFac)
    //    {
    //        EnterState();
    //    }

    //    public override void EnterState()
    //    {
    //        Ctrl.anim.SetTrigger("Attack");
    //        Ctrl.IsAttack = false;
    //    }

    //    protected override void UpdateState()
    //    {

    //    }

    //    public override void ExitState()
    //    {
    //        if (CurrentSubState != null)
    //            CurrentSubState.ExitState();

    //        Ctrl.anim.ResetTrigger("Attack");
    //    }

    //    protected override void CheckSwitchState()
    //    {
    //        if (!Ctrl.IsAttack)
    //        {
    //            SwitchState(Fac.IdleSubState());
    //        }
    //    }
    //}
}
