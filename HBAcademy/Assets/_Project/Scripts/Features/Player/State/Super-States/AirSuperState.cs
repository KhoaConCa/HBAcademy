using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.State
{
    public class AirSuperState : BaseState<PlayerController, StateFactory>
    {
        public AirSuperState(PlayerController ctrl, StateFactory stateFac) : base(ctrl, stateFac)
        {
            IsRootState = true; // Đặt trạng thái này là trạng thái gốc (root state).

            InitializeSubState();
            EnterState();
        }

        // <summary>
        /// Đặt trạng thái con (sub-state) dựa trên điều kiện hiện tại của nhân vật.
        /// </summary>
        protected override void InitializeSubState()
        {
            if (Ctrl.IsJump)
                SetSubState(Fac.JumpSuperState());
            else if (Ctrl.rg2D.velocity.y <= 0)
                SetSubState(Fac.FallSubState());
        }

        /// <summary>
        /// Thực hiện các hành động khi trạng thái được kích hoạt.
        /// </summary>
        public override void EnterState()
        {
            CurrentSubState?.EnterState();
        }

        /// <summary>
        /// Thực hiện các hành động khi nhân vật ở trên không.
        /// </summary>
        protected override void UpdateState()
        {
        }

        /// <summary>
        /// Thực hiện các hành động khi trạng thái kết thúc.
        /// </summary>
        public override void ExitState()
        {
            Ctrl.IsDoubleJump = false;

            if (CurrentSubState != null)
                CurrentSubState.ExitState();
        }

        /// <summary>
        /// Thực hiện kiểm tra điều kiện để chuyển đổi trạng thái (cùng cấp).
        /// </summary>
        protected override void CheckSwitchState()
        {
            if (Ctrl.IsGrounded)
                SwitchState(Fac.GroundSuperState());
        }
    }
}
