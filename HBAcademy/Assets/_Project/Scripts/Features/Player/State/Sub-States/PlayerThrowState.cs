using UnityEngine;
using Vox.Features.Player;
using Vox.Features.Player.Data;
using Vox.Features.SuperState;

namespace Vox.Features.SubState
{
    public class PlayerThrowState : PlayerAbilityState
    {
        #region --- Constructor ---

        public PlayerThrowState(PlayerController ctrl, PlayerStateFactory stateFac, PlayerData data, string animTrigger)
            : base(ctrl, stateFac, data, animTrigger) { }

        #endregion

        #region --- Methods ---

        public override void EnterState()
        {
            base.EnterState();
            Debug.Log("Throw");
            Ctrl.rg2D.velocity = new Vector2(0, Ctrl.rg2D.velocity.y);

            UnityEngine.Object.Instantiate(Ctrl.kunaiPrefab, Ctrl.throwPoint.position, Ctrl.throwPoint.rotation);
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
