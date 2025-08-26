using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using Vox.Ultilities.StateMachine;

namespace Vox.Features
{
    /// <summary>
    /// PlayerController - Developed by Duong Nhat Khoa on 2025/08/26. <br/>
    /// Handles player controls and state management.
    /// </summary>
    //public class PlayerStateMachine : StateController<PlayerStateMachine.PlayerState, C>
    //{
    //    public enum PlayerState
    //    {
    //        Idle,
    //        Run,
    //        Jump,
    //        Attack,
    //        Throw,
    //        Fall
    //    }

    //    void Awake()
    //    {
    //        _states[PlayerState.Idle] = new PlayerIdleState(PlayerState.Idle, _animator);
    //        _states[PlayerState.Run] = new PlayerRunState(PlayerState.Run, _animator);
    //        _states[PlayerState.Jump] = new PlayerJumpState(PlayerState.Jump, _animator);
    //        _states[PlayerState.Attack] = new PlayerAttackState(PlayerState.Attack, _animator);
    //        _states[PlayerState.Throw] = new PlayerThrowState(PlayerState.Throw, _animator);
    //        _states[PlayerState.Fall] = new PlayerFallState(PlayerState.Fall, _animator);

    //        _currentState = _states[PlayerState.Idle];
    //    }

    //    #region --- Methods ---



    //    #endregion

    //    #region --- Fields ---

    //    [SerializeField] private Animator _animator;

    //    #endregion
    //}
}
