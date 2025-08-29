using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.SuperState
{
    public class PlayerAbilityState : BaseState<PlayerController, PlayerStateFactory>
    {
        public PlayerAbilityState(PlayerController ctrl, PlayerStateFactory stateFac, PlayerData data) : base(ctrl, stateFac, data)
        {
            IsRootState = true;
        }

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        protected override void CheckSwitchState()
        {
            if (Ctrl.IsAbilityDone)
            {
                if (Ctrl.Grounded) //&& Ctrl.inputHandler.NormalizedInputY < 0.01f)
                    SwitchState(Fac.IdleState());
            }
            //} else
            //{
            //    SwitchState(Fac.InAirState());
            //}
        }

        protected override void UpdateState()
        {

        }

        protected override void CheckConditions()
        {

        }
    }
}
