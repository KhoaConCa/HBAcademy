using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vox.Featrures.SuperState;
using Vox.Ultilities.StateMachine;

namespace Vox.Features.SubState
{
    public class PlayerAirState : BaseState<PlayerController, PlayerStateFactory>
    {
        public PlayerAirState(PlayerController ctrl, PlayerStateFactory stateFac, PlayerData data) : base(ctrl, stateFac, data)
        {
            EnterState();
        }

        public override void EnterState()
        {
            throw new System.NotImplementedException();
        }

        public override void ExitState()
        {
            throw new System.NotImplementedException();
        }

        protected override void CheckConditions()
        {
            throw new System.NotImplementedException();
        }

        protected override void CheckSwitchState()
        {
            throw new System.NotImplementedException();
        }

        protected override void UpdateState()
        {
            throw new System.NotImplementedException();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}