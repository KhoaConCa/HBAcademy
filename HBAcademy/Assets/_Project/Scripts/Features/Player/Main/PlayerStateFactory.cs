using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using Vox.Featrures.SuperState;
using Vox.Features;
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

            _groundedState = new PlayerGroundedState(ctrl, this, data, "Grounded");
            _idleState = new PlayerIdleState(ctrl, this, data, "Idle");
            _runState = new PlayerRunState(ctrl, this, data, "Run");
            _fallState = new PlayerFallState(ctrl, this, data, "Fall");
            _attackState = new PlayerAttackState(ctrl, this, data, "Attack");
            _throwState = new PlayerThrowState(ctrl, this, data, "Throw");

            _jumpState = new PlayerJumpState(ctrl, this, data, "Jump");

            _airState = new PlayerAirState(ctrl, this, data, "Air");
        }

        #region --- Methods ---

        //public BaseState<PlayerController, PlayerStateFactory> GroundState() => new PlayerGroundedState(_controller, this, _data, "isGrounded");
        //public BaseState<PlayerController, PlayerStateFactory> IdleState() => new PlayerIdleState(_controller, this, _data, "Idle");
        //public BaseState<PlayerController, PlayerStateFactory> RunState() => new PlayerRunState(_controller, this, _data, "Run");
        //public BaseState<PlayerController, PlayerStateFactory> AirState() => new PlayerAirState(_controller, this, _data, "Attack");
        //public BaseState<PlayerController, PlayerStateFactory> AbilityState() => new PlayerAbilityState(_controller, this, _data);
        //public BaseState<PlayerController, PlayerStateFactory> JumpState() => new PlayerJumpState(_controller, this, _data, "Jump");
        //public BaseState<PlayerController, PlayerStateFactory> FallState() => new PlayerFallState(_controller, this, _data, "isFall");
        //public BaseState<PlayerController, PlayerStateFactory> AirSuperState() => new AirSuperState(_controller, this);
        //public BaseState<PlayerController, PlayerStateFactory> IdleSubState() => new IdleSubState(_controller, this);
        //public BaseState<PlayerController, PlayerStateFactory> RunSubState() => new RunSubState(_controller, this);
        //public BaseState<PlayerController, PlayerStateFactory> JumpSuperState() => new JumpSuperState(_controller, this);
        //public BaseState<PlayerController, PlayerStateFactory> FallSubState() => new FallSubState(_controller, this);
        //public BaseState<PlayerController, PlayerStateFactory> AttackSubState() => new AttackSubState(_controller, this);
        //public BaseState<PlayerController, PlayerStateFactory> ThrowSubState() => new ThrowSubState(_controller, this);

        public PlayerGroundedState GroundedState() => _groundedState;
        public PlayerIdleState IdleState() => _idleState;
        public PlayerRunState RunState() => _runState;
        public PlayerJumpState JumpState() => _jumpState;
        public PlayerAirState AirState() => _airState;
        public PlayerFallState FallState() => _fallState;
        public PlayerAttackState AttackState() => _attackState;
        public PlayerThrowState ThrowState() => _throwState;

        #endregion

        #region --- Fields ---

        private PlayerController _controller;
        private PlayerData _data;

        private PlayerGroundedState _groundedState;
        private PlayerIdleState _idleState;
        private PlayerRunState _runState;
        private PlayerJumpState _jumpState;
        private PlayerAirState _airState;
        private PlayerFallState _fallState;
        private PlayerAttackState _attackState;
        private PlayerThrowState _throwState;

        #endregion

    }


}
