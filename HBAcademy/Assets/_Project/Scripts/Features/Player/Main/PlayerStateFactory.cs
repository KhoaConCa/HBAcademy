using Vox.Featrures.SuperState;
using Vox.Features.Player.Data;
using Vox.Features.SubState;
using Vox.Features.SuperState;

namespace Vox.Features.Player
{
    /// <summary>
    /// PlayerStateFactory - Factory to create and manage player states.<br/>
    /// Developer: Duong Nhat Khoa - created on: 31/08/2025.
    /// </summary>
    public class PlayerStateFactory
    {
        #region --- Constructor ---

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

            _deathState = new PlayerDeathState(ctrl, this, data, "Die");
        }

        #endregion

        #region --- Methods ---
        public PlayerGroundedState GroundedState() => _groundedState;
        public PlayerIdleState IdleState() => _idleState;
        public PlayerRunState RunState() => _runState;
        public PlayerJumpState JumpState() => _jumpState;
        public PlayerAirState AirState() => _airState;
        public PlayerFallState FallState() => _fallState;
        public PlayerAttackState AttackState() => _attackState;
        public PlayerThrowState ThrowState() => _throwState;

        public PlayerDeathState DeathState() => _deathState;

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
        private PlayerDeathState _deathState;

        #endregion

    }


}
