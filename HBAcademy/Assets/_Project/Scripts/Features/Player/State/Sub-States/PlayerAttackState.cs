using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Features.SuperState;

namespace Vox.Features.SubState
{
    public class PlayerAttackState : PlayerAbilityState //: BaseState<PlayerController, PlayerStateFactory>
    {
        public PlayerAttackState(PlayerController ctrl, PlayerStateFactory stateFac, PlayerData data, string animTrigger) 
            : base(ctrl, stateFac, data, animTrigger) { }

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
    }
}
