using UnityEngine;
using Vox.Features.Player;
using Vox.Features.Player.Data;
using Vox.Features.SuperState;

namespace Vox.Features.SubState
{
    /// <summary>
    /// JumpState - Sub-state.<br/>
    /// Developer: Duong Nhat Khoa - created on: 31/08/2025.
    /// </summary>
    public class PlayerJumpState : PlayerAbilityState
    {
        #region --- Constructor ---
        public PlayerJumpState(PlayerController ctrl, PlayerStateFactory fac, PlayerData data, string animTrigger) 
            : base(ctrl, fac, data, animTrigger) { }

        #endregion

        #region --- Methods ---

        public override void EnterState()
        {
            Debug.Log("Jump");

            base.EnterState();

            Ctrl.inputHandler.UseJumpInput();
            _isAbilityDone = true;

            Fac.AirState().SetIsJumping();

            Ctrl.rg2D.velocity = new Vector2(Ctrl.rg2D.velocity.x, Ctrl.playerData.jumpForce);
            
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        protected override void CheckSwitchState()
        {

        }

        protected override void UpdateState()
        {
            Ctrl.rg2D.velocity = new Vector2(Ctrl.playerData.moveSpeed * Ctrl.inputHandler.NormalizedInputX * Time.fixedDeltaTime
                                , Ctrl.rg2D.velocity.y);

            if (Ctrl.inputHandler.NormalizedInputX != 0)
                Ctrl.transform.rotation = Quaternion.Euler(new Vector3(0, Ctrl.inputHandler.NormalizedInputX >= 0 ? 0 : 180, 0));

            if (Ctrl.rg2D.velocity.y < 0)
            {
                SwitchState(Fac.FallState());
            }
        }

        #endregion
    }
}