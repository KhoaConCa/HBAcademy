using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.State
{
    public class IdleSubState : BaseState<PlayerController, StateFactory>
    {
        public IdleSubState(PlayerController ctrl, StateFactory stateFac) : base(ctrl, stateFac)
        {
            EnterState();
        }

        public override void EnterState()
        {
            Ctrl.anim.SetBool("isMove", false);
        }

        protected override void UpdateState()
        {
            float moveSpeed = Mathf.Clamp(Mathf.Abs(Ctrl.rg2D.velocity.x), 0, 2);
            if (moveSpeed > 0.01f)
                Ctrl.rg2D.velocity = new Vector2(moveSpeed - acceleration, Ctrl.rg2D.velocity.y);
        }

        public override void ExitState()
        {
            if (CurrentSubState != null)
                CurrentSubState.ExitState();
        }

        protected override void CheckSwitchState()
        {
            if (Ctrl.IsMove)
                SwitchState(Fac.RunSubState());
        }

        #region --- Fields ---

        private float acceleration = 0.4f;

        #endregion
    }
}
