using UnityEngine;
using Vox.Featrures.SuperState;
using Vox.Features.Player;
using Vox.Features.Player.Data;

namespace Vox.Features.SubState
{
    /// <summary>
    /// PlayerIdleState - Sub-state.<br/>
    /// Developer: Duong Nhat Khoa - created on: 31/08/2025.
    /// </summary>
    public class PlayerIdleState : PlayerGroundedState
    {
        #region --- Constructor ---

        public PlayerIdleState(PlayerController ctrl, PlayerStateFactory stateFac, PlayerData data, string animTrigger) 
            : base(ctrl, stateFac, data, animTrigger) { }

        #endregion

        #region --- Methods ---

        public override void EnterState()
        {
            base.EnterState();

            Debug.Log("Idle");

            float moveSpeed = Mathf.Clamp(Mathf.Abs(Ctrl.rg2D.velocity.x), 0, 2);

            if (moveSpeed > 0.01f)
            {
                Ctrl.rg2D.velocity = new Vector2(moveSpeed - _acceleration, Ctrl.rg2D.velocity.y);
            }
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        protected override void CheckSwitchState()
        {
            base.CheckSwitchState();

            if (!isExitingState && _xInput != 0)
            {
                SwitchState(Fac.RunState());
            }
        }

        protected override void UpdateState()
        {
            base.UpdateState();
        }

        #endregion

        #region --- Fields ---

        [SerializeField] private float _acceleration = 0.4f;

        #endregion
    }
}