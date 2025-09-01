using UnityEngine;
using Vox.Features.Player;
using Vox.Features.Player.Data;
using Vox.Features.SuperState;

namespace Vox.Features.SubState
{
    /// <summary>
    /// PlayerAttackState - Sub-state.<br/>
    /// Developer: Duong Nhat Khoa - created on: 01/09/2025.
    /// </summary>
    public class PlayerAttackState : PlayerAbilityState
    {
        #region --- Constructor ---

        public PlayerAttackState(PlayerController ctrl, PlayerStateFactory stateFac, PlayerData data, string animTrigger) 
            : base(ctrl, stateFac, data, animTrigger) { }

        #endregion

        #region --- Methods ---

        public override void EnterState()
        {
            base.EnterState();
            Debug.Log("Attack");
            Ctrl.rg2D.velocity = new Vector2(0, Ctrl.rg2D.velocity.y);
        }

        public override void ExitState()
        {
            base.ExitState();

        }

        protected override void CheckSwitchState()
        {
            if (_isAbilityDone)
            {
                if (_isGrounded && Ctrl.rg2D.velocity.y < 0.01f)
                    SwitchState(Fac.IdleState());
            }
        }

        protected override void UpdateState()
        {

        }

        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();

            _isAbilityDone = true;
        }

        #endregion
    }
}
