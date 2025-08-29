using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.State
{
    //public class JumpSuperState : BaseState<PlayerController, StateFactory>
    //{
    //    public JumpSuperState(PlayerController ctrl, StateFactory stateFac) : base(ctrl, stateFac)
    //    {
    //        InitializeSubState();
    //        EnterState();
    //    }

    //    protected override void InitializeSubState()
    //    {
    //        Debug.Log("Jump");
    //        if (!Ctrl.IsMove)
    //            SetSubState(Fac.IdleSubState());
    //        else
    //            SetSubState(Fac.RunSubState());
    //    }

    //    public override void EnterState()
    //    {
    //        CurrentSubState.EnterState();

    //        if (Ctrl.IsGrounded)
    //        {
    //            Ctrl.anim.SetTrigger("Jump");
    //            Ctrl.rg2D.velocity = new Vector2(Ctrl.rg2D.velocity.x, 7f);
    //        }
    //    }

    //    protected override void UpdateState()
    //    {
    //        //if (Ctrl.IsDoubleJump && Ctrl.JumpTriggered)
    //        //    EnterState();
    //    }

    //    public override void ExitState()
    //    {
    //        if (CurrentSubState != null)
    //            CurrentSubState.ExitState();
    //    }

    //    protected override void CheckSwitchState()
    //    {
    //        if (Ctrl.rg2D.velocity.y <= 0)
    //            SwitchState(Fac.FallSubState());
    //    }
    //}

}