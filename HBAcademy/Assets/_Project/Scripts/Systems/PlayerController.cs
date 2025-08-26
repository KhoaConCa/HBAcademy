using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using Vox.Ultilities.StateMachine;

public class PlayerController : StateController<PlayerController.PlayerState>
{
    public enum PlayerState
    {
        Idle,
        Walk,
        Run,
        Jump,
        Attack
    }

    void Awake()
    {
        _states[PlayerState.Idle] = new IdleState(PlayerState.Idle);

        _currentState = _states[PlayerState.Idle];
    }

    private void Update()
    {
        if (_currentState == _states[PlayerState.Idle]) Debug.Log("Player is Idle");
    }
}
