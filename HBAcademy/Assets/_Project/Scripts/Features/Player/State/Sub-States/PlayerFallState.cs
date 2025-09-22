using UnityEngine;
using Vox.Featrures.SuperState;
using Vox.Features.Player;
using Vox.Features.Player.Data;

namespace Vox.Features.SubState
{
    /// <summary>
    /// PlayerFallState - Sub-state.<br/>
    /// Developer: Duong Nhat Khoa - created on: 31/08/2025.
    /// </summary>
    public class PlayerFallState : PlayerGroundedState
    {
        #region --- Constructor ---

        public PlayerFallState(PlayerController ctrl, PlayerStateFactory fac, PlayerData data, string animTrigger) 
            : base(ctrl, fac, data, animTrigger) { }

        #endregion

        #region --- Methods ---

        public override void EnterState()
        {
            base.EnterState();
            Debug.Log("Fall");

            Ctrl.anim.SetBool("isFall", true);
            Fac.AirState().ResetIsFalling();
        }

        public override void ExitState()
        {
            Ctrl.anim.SetBool("isFall", false);
        }

        protected override void CheckSwitchState()
        {
            Debug.Log(Ctrl.IsDead);
            if (!isExitingState)
            {
                if (!_isGrounded && _xInput != 0)
                {
                    Ctrl.rg2D.velocity = new Vector2(_xInput, Ctrl.rg2D.velocity.y);
                }
                else if (isAnimationFinished)
                {
                    SwitchState(Fac.IdleState());
                }
                else if (_isGrounded && Ctrl.inputHandler.NormalizedInputX != 0)
                {
                    SwitchState(Fac.RunState());
                }
                else if (Ctrl.IsDead)
                {
                    SwitchState(Fac.DeathState());
                }
            }
        }

        protected override void UpdateState()
        {
            Ctrl.anim.SetFloat("yVelocity", Ctrl.rg2D.velocity.y);
            Ctrl.rg2D.velocity = new Vector2(Ctrl.playerData.moveSpeed * Ctrl.inputHandler.NormalizedInputX * Time.fixedDeltaTime
                    , Ctrl.rg2D.velocity.y);

            if (Ctrl.inputHandler.NormalizedInputX != 0)
                Ctrl.transform.rotation = Quaternion.Euler(new Vector3(0, Ctrl.inputHandler.NormalizedInputX >= 0 ? 0 : 180, 0));

            if (_isGrounded)
                isAnimationFinished = true;
        }

        #endregion
    }
}