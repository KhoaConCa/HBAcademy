using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using Vox.Featrures.SuperState;
using Vox.Features;
using Vox.Features.State;
using Vox.Features.SubState;
using Vox.Features.SuperState;
using Vox.Ultilities.StateMachine;

namespace Vox.Features
{
    public class PlayerStateFactory
    {
        public PlayerStateFactory(PlayerController ctrl, PlayerData data)
        {
            _controller = ctrl;
            _data = data;
        }

        #region --- Methods ---

        public BaseState<PlayerController, PlayerStateFactory> GroundState() => new PlayerGroundedState(_controller, this, _data);
        public BaseState<PlayerController, PlayerStateFactory> IdleState() => new PlayerIdleState(_controller, this, _data);
        public BaseState<PlayerController, PlayerStateFactory> RunState() => new PlayerRunState(_controller, this, _data);
        public BaseState<PlayerController, PlayerStateFactory> AbilityState() => new PlayerAbilityState(_controller, this, _data);
        public BaseState<PlayerController, PlayerStateFactory> JumpState() => new PlayerJumpState(_controller, this, _data);
        public BaseState<PlayerController, PlayerStateFactory> FallState() => new PlayerFallState(_controller, this, _data);
        //public BaseState<PlayerController, PlayerStateFactory> AirSuperState() => new AirSuperState(_controller, this);
        //public BaseState<PlayerController, PlayerStateFactory> IdleSubState() => new IdleSubState(_controller, this);
        //public BaseState<PlayerController, PlayerStateFactory> RunSubState() => new RunSubState(_controller, this);
        //public BaseState<PlayerController, PlayerStateFactory> JumpSuperState() => new JumpSuperState(_controller, this);
        //public BaseState<PlayerController, PlayerStateFactory> FallSubState() => new FallSubState(_controller, this);
        //public BaseState<PlayerController, PlayerStateFactory> AttackSubState() => new AttackSubState(_controller, this);
        //public BaseState<PlayerController, PlayerStateFactory> ThrowSubState() => new ThrowSubState(_controller, this);
        #endregion

        #region --- Fields ---

        private PlayerController _controller;
        private PlayerData _data;

        #endregion

    }


}
