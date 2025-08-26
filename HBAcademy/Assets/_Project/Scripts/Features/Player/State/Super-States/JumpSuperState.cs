using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.State
{
    /// <summary>
    /// JumpState - Thực hiện trạng thái khi nhân vật đang nhảy hoặc đang thực hiện cú nhảy đôi (double jump).
    /// Tác giả: Nguyễn Ngọc Phú, Ngày tạo: 24/06/2024.
    /// </summary>
    public class JumpSuperState : BaseState<PlayerController, StateFactory>
    {
        /// <summary>
        /// Khởi tạo JumpState với PlayerController và StateFactory.
        /// </summary>
        /// <param name="ctrl"> là một biến Controller. </param>
        /// <param name="stateFac"> là một biến Factory. </param>
        public JumpSuperState(PlayerController ctrl, StateFactory stateFac) : base(ctrl, stateFac)
        {
            InitializeSubState();
            EnterState();
        }

        /// <summary>
        /// Khởi tạo trạng thái con (sub-state) dựa trên điều kiện hiện tại của nhân vật.
        /// </summary>
        protected override void InitializeSubState()
        {
            if (!Ctrl.IsMove)
                SetSubState(Fac.IdleSubState());
            else
                SetSubState(Fac.RunSubState());
        }

        /// <summary>
        /// Thực hiện các hành động khi trạng thái được kích hoạt.
        /// </summary>
        public override void EnterState()
        {
            Debug.Log("Jump");
            CurrentSubState.EnterState();
            Ctrl.anim.SetTrigger("Jump");
            if (Ctrl.IsGrounded)
            {
                Ctrl.rg2D.velocity = new Vector2(Ctrl.rg2D.velocity.x, 10f);
                Ctrl.IsDoubleJump = true;
            }
            else if (Ctrl.IsDoubleJump)
            {
                Ctrl.rg2D.velocity = new Vector2(Ctrl.rg2D.velocity.x, 8f);
                Ctrl.IsDoubleJump = false;
            }
        }

        /// <summary>
        /// Thực hiện các hành động khi nhân vật đang nhảy hoặc thực hiện cú nhảy đôi (double jump).
        /// </summary>
        protected override void UpdateState()
        {
            Debug.Log(Ctrl.IsJump);
            if (Ctrl.IsDoubleJump && Ctrl.JumpTriggered)
                EnterState();
        }

        /// <summary>
        /// Thực hiện các hành động khi trạng thái kết thúc.
        /// </summary>
        public override void ExitState()
        {
            if (CurrentSubState != null)
                CurrentSubState.ExitState();
        }

        /// <summary>
        /// Kiểm tra điều kiện để chuyển đổi trạng thái (cùng cấp).
        /// </summary>
        protected override void CheckSwitchState()
        {
            if (Ctrl.rg2D.velocity.y <= 0)
                SwitchState(Fac.FallSubState());
        }
    }

}