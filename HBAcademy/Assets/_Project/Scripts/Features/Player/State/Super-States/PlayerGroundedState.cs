using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Features;
using Vox.Ultilities.StateMachine;

namespace Vox.Featrures.SuperState
{
    public class PlayerGroundedState : BaseState<PlayerController, PlayerStateFactory>
    {
        public PlayerGroundedState(PlayerController ctrl, PlayerStateFactory stateFac, PlayerData data) : base(ctrl, stateFac, data)
        {
            IsRootState = true;

            InitializeSubState();
            EnterState();
        }

        protected override void InitializeSubState()
        {
            SetSubState(Fac.IdleState());
        }
         
        public override void EnterState()
        {
            Debug.Log("Grounded");
            CurrentSubState.EnterState();
        }

        public override void ExitState()
        {
            if (CurrentSubState != null)
                CurrentSubState.ExitState();
        }

        protected override void CheckSwitchState()
        {
            if (!Ctrl.Grounded)
                Ctrl.anim.SetBool("isGrounded", false);
        }

        protected override void UpdateState()
        {
            Ctrl.anim.SetBool("isGrounded", true);
        }

        protected override void CheckConditions()
        {
            Ctrl.Grounded = Ctrl.col2D.Cast(Vector2.down, Ctrl.contactFilter2D, new RaycastHit2D[5], 0.05f) > 0;
        }

        #region --- Fields ---

        //protected bool _isGrounded;

        #endregion
    }
}