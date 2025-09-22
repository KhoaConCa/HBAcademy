using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Featrures.SuperState;
using Vox.Features.Player;
using Vox.Features.Player.Data;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.SubState
{
    public class PlayerRunState : PlayerGroundedState
    {
        #region --- Constructor ---

        public PlayerRunState(PlayerController ctrl, PlayerStateFactory fac, PlayerData data, string animTrigger) 
            : base(ctrl, fac, data, animTrigger) { }

        #endregion

        #region --- Methods ---

        public override void EnterState()
        {
            base.EnterState();

            Debug.Log("Run");
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        protected override void CheckSwitchState()
        {
            base.CheckSwitchState();

            if (!isExitingState && _xInput == 0)
            {
                SwitchState(Fac.IdleState());
            }
            else if (!_isGrounded && _xInput != 0)
            {
                SwitchState(Fac.FallState());
            }
        }

        protected override void UpdateState()
        {
            base.UpdateState();
            MovementLogic();
        }

        public void MovementLogic()
        {
            Ctrl.rg2D.velocity = new Vector2(Ctrl.playerData.moveSpeed * _xInput * Time.fixedDeltaTime
                                                        , Ctrl.rg2D.velocity.y);

            if (_xInput != 0)
                Ctrl.transform.rotation = Quaternion.Euler(new Vector3(0, _xInput >= 0 ? 0 : 180, 0));
        }

        #endregion
    }
}