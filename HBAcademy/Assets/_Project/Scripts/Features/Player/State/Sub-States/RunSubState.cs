using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Features;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.State
{
    //public class RunSubState : BaseState<PlayerController, StateFactory>
    //{
    //    public RunSubState(PlayerController ctrl, StateFactory stateFac) : base(ctrl, stateFac)
    //    {
    //        EnterState();
    //    }

    //    public override void EnterState()
    //    {
    //        Debug.Log("Run");
    //        Ctrl.anim.SetBool("isMove", true);
    //        Ctrl.anim.SetTrigger("Run");
    //    }

    //    protected override void UpdateState()
    //    {
    //        Ctrl.rg2D.velocity = new Vector2(Ctrl.playerData.moveSpeed * Ctrl.MoveDirection * Time.fixedDeltaTime, Ctrl.rg2D.velocity.y);

    //        //Vector3 playerDir = Ctrl.transform.localScale;
    //        //if (Ctrl.MoveDirection != 0) //&& Mathf.Sign(playerDir.x) != Mathf.Sign(Ctrl.MoveDirection))
            
    //        if (Ctrl.MoveDirection != 0)
    //            Ctrl.transform.rotation = Quaternion.Euler(new Vector3(0, Ctrl.MoveDirection >= 0 ? 0 : 180, 0));
    //    }

    //    public override void ExitState()
    //    {
    //        if (CurrentSubState != null)
    //            CurrentSubState.ExitState();
    //    }

    //    protected override void CheckSwitchState()
    //    {
    //        if (!Ctrl.IsMove)
    //            SwitchState(Fac.IdleSubState());
    //    }
    //}
}
