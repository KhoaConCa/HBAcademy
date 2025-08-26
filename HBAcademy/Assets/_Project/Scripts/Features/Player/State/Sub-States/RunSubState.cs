using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Features;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.State
{
    /// <summary>
    /// RunState - Thực hiện trạng thái khi nhân vật đang chạy.
    /// Tác giả: Nguyễn Ngọc Phú, Ngày tạo: 24/06/2024.
    /// </summary>
    public class RunSubState : BaseState<PlayerController, StateFactory>
    {
        /// <summary>
        /// Thực hiện khởi tạo RunState với PlayerController và StateFactory.
        /// </summary>
        /// <param name="ctrl"> là một biến Controller. </param>
        /// <param name="stateFac"> là một biến Factory. </param>
        public RunSubState(PlayerController ctrl, StateFactory stateFac) : base(ctrl, stateFac)
        {
            EnterState();
        }

        /// <summary>
        /// Thực hiện các hành động khi trạng thái được kích hoạt.
        /// </summary>
        public override void EnterState()
        {
            Debug.Log("Run");
            Ctrl.anim.SetTrigger("Run");
        }

        /// <summary>
        /// Thực hiện các hành động khi nhân vật đang chạy.
        /// </summary>
        protected override void UpdateState()
        {
            Ctrl.rg2D.velocity = new Vector2(_moveSpeed * Ctrl.MoveDirection, Ctrl.rg2D.velocity.y);

            Vector3 playerDir = Ctrl.transform.localScale;
            if (Ctrl.MoveDirection != 0 && Mathf.Sign(playerDir.x) != Mathf.Sign(Ctrl.MoveDirection))
                Ctrl.transform.localScale = new Vector2(-playerDir.x, playerDir.y);
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
        /// Kiểm tra điều kiện để chuyển đổi trạng thái.
        /// </summary>
        protected override void CheckSwitchState()
        {
            if (!Ctrl.IsMove)
                SwitchState(Fac.IdleSubState());
        }

        #region --- Fields ---

        private float _moveSpeed = 4f;

        #endregion
    }
}
