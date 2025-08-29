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

            InitializeSubState();
            EnterState();
        }

        protected override void InitializeSubState()
        {
            
        }

        public override void EnterState()
        {

        }

        public override void ExitState()
        {

        }

        protected override void CheckSwitchState()
        {

        }

        protected override void UpdateState()
        {

        }

        protected override void CheckConditions()
        {

        }
    }
}
