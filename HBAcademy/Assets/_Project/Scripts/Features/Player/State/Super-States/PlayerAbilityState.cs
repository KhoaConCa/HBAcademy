using UnityEngine;
using Vox.Features.Player;
using Vox.Features.Player.Data;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.SuperState
{
    /// <summary>
    /// PlayerAbilityState - Super-state.<br/>
    /// Developer: Duong Nhat Khoa - created on: 31/08/2025.
    /// </summary>
    public class PlayerAbilityState : BaseState<PlayerController, PlayerStateFactory>
    {
        #region --- Constructor ---

        public PlayerAbilityState(PlayerController ctrl, PlayerStateFactory stateFac, PlayerData data, string animTrigger) 
            : base(ctrl, stateFac, data, animTrigger) { }

        #endregion

        #region --- Methods ---

        public override void EnterState()
        {
            base.EnterState();
            Debug.Log("Ability");

            CheckConditions();
            Ctrl.anim.SetBool("isGrounded", _isGrounded);

            _isAbilityDone = false;
        }

        public override void ExitState()
        {
            base.ExitState();

            Ctrl.anim.SetBool("isGrounded", _isGrounded);
        }

        protected override void CheckSwitchState()
        {
            if (_isAbilityDone)
            {
                if (_isGrounded && Ctrl.rg2D.velocity.y < 0.01f)
                    SwitchState(Fac.IdleState());
                else
                {
                    SwitchState(Fac.AirState());
                }
            }
        }

        protected override void UpdateState()
        {

        }

        protected override void CheckConditions()
        {
            _isGrounded = Ctrl.col2D.Cast(Vector2.down, Ctrl.contactFilter2D, new RaycastHit2D[5], 0.05f) > 0;

            Ctrl.anim.SetBool("isGrounded", _isGrounded);
        }

        #endregion

        #region --- Fields ---

        protected bool _isAbilityDone;

        protected bool _isGrounded;

        #endregion
    }
}
